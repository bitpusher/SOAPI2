using System;
using Newtonsoft.Json;
using SOAPI2.Converters;
using SOAPI2.Domain;
using System.Collections.Generic;
using Salient.ReliableHttpClient;

namespace SOAPI2
{

	public partial class Client
	{
		public class __global
		{
		
		
		private Client _client;
		
		public __global(Client client){ this._client = client;}
		public void BeginInvalidateAccessTokens(ReliableAsyncCallback callback, object state, string accessTokens, int? page=null, int? pagesize=null){}
		
		public void EndInvalidateAccessTokens(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<AccessTokenObject> InvalidateAccessTokens(string accessTokens, int? page=null, int? pagesize=null){ return null;}
		
		public void BeginReadAccessTokens(ReliableAsyncCallback callback, object state, string accessTokens, int? page=null, int? pagesize=null){}
		
		public void EndReadAccessTokens(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<AccessTokenObject> ReadAccessTokens(string accessTokens, int? page=null, int? pagesize=null){ return null;}
		
		public void BeginApplicationDeAuthenticate(ReliableAsyncCallback callback, object state, string accessTokens, int? page=null, int? pagesize=null){}
		
		public void EndApplicationDeAuthenticate(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<AccessTokenObject> ApplicationDeAuthenticate(string accessTokens, int? page=null, int? pagesize=null){ return null;}
		
		public void BeginErrors(ReliableAsyncCallback callback, object state, int? page=null, int? pagesize=null){}
		
		public void EndErrors(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<ErrorObject> Errors(int? page=null, int? pagesize=null){ return null;}
		
		public void BeginSimulateError(ReliableAsyncCallback callback, object state, int id){}
		
		public void EndSimulateError(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<ErrorObject> SimulateError(int id){ return null;}
		
		public void BeginCreateFilter(ReliableAsyncCallback callback, object state, string include=null, string exclude=null, string @base=null, string @unsafe=null){}
		
		public void EndCreateFilter(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<FilterObject> CreateFilter(string include=null, string exclude=null, string @base=null, string @unsafe=null){ return null;}
		
		public void BeginReadFilter(ReliableAsyncCallback callback, object state, string filters){}
		
		public void EndReadFilter(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<FilterObject> ReadFilter(string filters){ return null;}
		
		public void BeginInbox(ReliableAsyncCallback callback, object state, int? page=null, int? pagesize=null, string access_token=null){}
		
		public void EndInbox(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<InboxItemObject> Inbox(int? page=null, int? pagesize=null, string access_token=null){ return null;}
		
		public void BeginInboxUnread(ReliableAsyncCallback callback, object state, int? page=null, int? pagesize=null, string access_token=null, DateTime? since=null){}
		
		public void EndInboxUnread(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<InboxItemObject> InboxUnread(int? page=null, int? pagesize=null, string access_token=null, DateTime? since=null){ return null;}
		
		public void BeginNotifications(ReliableAsyncCallback callback, object state, int? page=null, int? pagesize=null, string access_token=null){}
		
		public void EndNotifications(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<NotificationObject> Notifications(int? page=null, int? pagesize=null, string access_token=null){ return null;}
		
		public void BeginUnreadNotifications(ReliableAsyncCallback callback, object state, int? page=null, int? pagesize=null, string access_token=null){}
		
		public void EndUnreadNotifications(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<NotificationObject> UnreadNotifications(int? page=null, int? pagesize=null, string access_token=null){ return null;}
		
		public void BeginSites(ReliableAsyncCallback callback, object state, int? page=null, int? pagesize=null){}
		
		public void EndSites(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<SiteObject> Sites(int? page=null, int? pagesize=null){ return null;}
		
		public void BeginAssociatedUsers(ReliableAsyncCallback callback, object state, string ids, int? page=null, int? pagesize=null){}
		
		public void EndAssociatedUsers(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<NetworkUserObject> AssociatedUsers(string ids, int? page=null, int? pagesize=null){ return null;}
		
		public void BeginMeAssociatedUsers(ReliableAsyncCallback callback, object state, int? page=null, int? pagesize=null, string access_token=null){}
		
		public void EndMeAssociatedUsers(ReliableAsyncResult asyncResult){}
		
		
		public ListOf<NetworkUserObject> MeAssociatedUsers(int? page=null, int? pagesize=null, string access_token=null){ return null;}
		
		}
	}

}
