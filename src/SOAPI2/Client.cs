using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAPI2.Domain;
using Salient.ReliableHttpClient;
using Salient.ReliableHttpClient.Serialization;
using Salient.ReliableHttpClient.Serialization.Newtonsoft;

namespace SOAPI2
{
    public partial class Client : ClientBase
    {
        private class NullObject
        {
        }
        private bool _disposed;
        private string _applicationId;
        private string _userAgent = "SOAPI2 alpha testing";
        private string _rootUrl = "https://api.stackexchange.com/2.1";

        public Client(string applicationId)
            : base(new Serializer())
        {

            _applicationId = applicationId;

        }

        public Guid BeginRequest(RequestMethod method, string target, string uriTemplate,
                                 Dictionary<string, object> parameters, ContentType requestContentType,
                                 ContentType responseContentType, TimeSpan cacheDuration, int timeout, int retryCount,
                                 ReliableAsyncCallback callback, object state)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }

            target = PrepareUrl(_rootUrl, target);
            var param = new Dictionary<string, object>(parameters ?? new Dictionary<string, object>());

            Dictionary<string, string> headers = new Dictionary<string, string>();
            return base.BeginRequest(method, target, uriTemplate, headers, param, requestContentType,
                                     responseContentType, cacheDuration, timeout, retryCount, callback, state);
        }

        public override string EndRequest(ReliableAsyncResult result)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
            string responseText;
            try
            {
                responseText = base.EndRequest(result);
            }
            catch (ReliableHttpException ex)
            {
                ReliableHttpException ex2 = null;

                if (!string.IsNullOrEmpty(ex.ResponseText))
                {
                    try
                    {
                        ex2 = CreateApiException(ex.ResponseText);
                    }
                    catch
                    {
                        // swallow
                    }
                }

                if (ex2 != null)
                {
                    throw ex2;
                }

                throw;
            }
            catch (Exception ex)
            {
                throw ReliableHttpException.Create(ex);
            }

            if (responseText.Contains("\"HttpStatus\"") && responseText.Contains("\"ErrorMessage\"") &&
                responseText.Contains("\"ErrorCode\""))
            {

                ReliableHttpException ex2 = CreateApiException(responseText);
                if (ex2 != null)
                {
                    throw ex2;
                }
            }

            // at this point, if we don't have json then it is an error

            try
            {
                Serializer.DeserializeObject<NullObject>(responseText);
            }
            catch
            {

                throw CreateApiException(responseText);
            }

            return responseText;
        }

        private ReliableHttpException CreateApiException(string responseText)
        {
            ReliableHttpException ex2 = null;
            try
            {
                ErrorObject err = Serializer.DeserializeObject<ErrorObject>(responseText);
                switch (err.ErrorId)
                {

                    default:
                        ex2 = new ReliableHttpException(err.Description);
                        break;

                }

                ex2.ResponseText = responseText;
                ex2.ErrorCode = err.ErrorId;
                ex2.HttpStatus = 400;
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
                //swallow
            }
            return ex2;
        }

        private static string PrepareUrl(string url, string target)
        {
            target = target ?? "";

            return !url.EndsWith("/") && !target.StartsWith("/") ? url + "/" + target : url + target;
        }

        protected override void Dispose(bool disposing)
        {
            _disposed = true;
            if (disposing)
            {
                // dispose components
            }

            base.Dispose(disposing);
        }
    }

    
}