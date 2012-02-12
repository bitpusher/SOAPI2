using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using CityIndex.JsonClient;
using SOAPI2.Converters;
using SOAPI2.Model;
namespace SOAPI2
{
	public partial class SoapiClient
	{
        public SoapiClient(string apiKey, string appId) // #TODO: uri from SMD target
            : base(new Uri("https://api.stackexchange.com/2.0/"), new RequestController(TimeSpan.FromSeconds(0), 2, new RequestFactory(), new ErrorResponseDTOJsonExceptionFactory(), new ThrottledRequestQueue(TimeSpan.FromSeconds(5), 30, 10, "data"), new ThrottledRequestQueue(TimeSpan.FromSeconds(5), 30, 10, "trading"), new ThrottledRequestQueue(TimeSpan.FromSeconds(5), 30, 10, "default")))
        {

   

#if SILVERLIGHT
#if WINDOWS_PHONE
		  UserAgent = "SOAPI2.PHONE7."+ GetVersionNumber();
#else
		  UserAgent = "SOAPI2.SILVERLIGHT."+ GetVersionNumber();
#endif
#else
            UserAgent = "SOAPI2." + GetVersionNumber();
#endif
            _client = this;
            _appId = appId;
            _apiKey = apiKey;
		    this.Answers = new _Answers(this);
		    this.Badges = new _Badges(this);
		    this.Comments = new _Comments(this);
		    this.Events = new _Events(this);
		    this.Posts = new _Posts(this);
		    this.Privileges = new _Privileges(this);
		    this.Questions = new _Questions(this);
		    this.Revisions = new _Revisions(this);
		    this.Search = new _Search(this);
		    this.Suggested_Edits = new _Suggested_Edits(this);
		    this.Info = new _Info(this);
		    this.Tags = new _Tags(this);
		    this.Users = new _Users(this);
		    this.Access_Tokens = new _Access_Tokens(this);
		    this.Applications = new _Applications(this);
		    this.Errors = new _Errors(this);
		    this.Filters = new _Filters(this);
		    this.Inbox = new _Inbox(this);
		    this.Sites = new _Sites(this);

        }
        public SoapiClient(string apiKey, string appId,Uri uri, IRequestController requestController)
            : base(uri, requestController)
        {

   
#if SILVERLIGHT
#if WINDOWS_PHONE
		  UserAgent = "SOAPI2.PHONE7."+ GetVersionNumber();
#else
		  UserAgent = "SOAPI2.SILVERLIGHT."+ GetVersionNumber();
#endif
#else
            UserAgent = "SOAPI2." + GetVersionNumber();
#endif
            _client = this;
            _appId = appId;
            _apiKey = apiKey;

		    this.Answers = new _Answers(this);
		    this.Badges = new _Badges(this);
		    this.Comments = new _Comments(this);
		    this.Events = new _Events(this);
		    this.Posts = new _Posts(this);
		    this.Privileges = new _Privileges(this);
		    this.Questions = new _Questions(this);
		    this.Revisions = new _Revisions(this);
		    this.Search = new _Search(this);
		    this.Suggested_Edits = new _Suggested_Edits(this);
		    this.Info = new _Info(this);
		    this.Tags = new _Tags(this);
		    this.Users = new _Users(this);
		    this.Access_Tokens = new _Access_Tokens(this);
		    this.Applications = new _Applications(this);
		    this.Errors = new _Errors(this);
		    this.Filters = new _Filters(this);
		    this.Inbox = new _Inbox(this);
		    this.Sites = new _Sites(this);
        }
		public class _Answers
		{
			private SoapiClient _client;
			public _Answers(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<AnswerClass> Answers(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortAnswers? sort)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<AnswerClass>>("answers", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<AnswerClass> AnswersByIds(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortAnswersByIds? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<AnswerClass>>("answers", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<CommentClass> AnswersByIdsComments(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortAnswersByIdsComments? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/comments?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<CommentClass>>("answers", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Answers Answers{get; private set;}
		public class _Badges
		{
			private SoapiClient _client;
			public _Badges(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<BadgeClass> Badges(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortBadges? sort, string inname)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&inname={inname}");
				return _client.Request<ResponseWrapperClass<BadgeClass>>("badges", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"inname",inname},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<BadgeClass> BadgesByIds(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortBadgesByIds? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<BadgeClass>>("badges", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<BadgeClass> BadgesName(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortBadgesName? sort, string inname)
			{
				string uriTemplate = _client.AppendApiKey("/name?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&inname={inname}");
				return _client.Request<ResponseWrapperClass<BadgeClass>>("badges", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"inname",inname},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<BadgeClass> BadgesRecipients(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate)
			{
				string uriTemplate = _client.AppendApiKey("/recipients?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}");
				return _client.Request<ResponseWrapperClass<BadgeClass>>("badges", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<BadgeClass> BadgesByIdsRecipients(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/recipients?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}");
				return _client.Request<ResponseWrapperClass<BadgeClass>>("badges", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<BadgeClass> BadgesTags(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortBadgesTags? sort, string inname)
			{
				string uriTemplate = _client.AppendApiKey("/tags?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&inname={inname}");
				return _client.Request<ResponseWrapperClass<BadgeClass>>("badges", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"inname",inname},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Badges Badges{get; private set;}
		public class _Comments
		{
			private SoapiClient _client;
			public _Comments(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<CommentClass> Comments(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortComments? sort)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<CommentClass>>("comments", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<CommentClass> CommentsByIds(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortCommentsByIds? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<CommentClass>>("comments", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Comments Comments{get; private set;}
		public class _Events
		{
			private SoapiClient _client;
			public _Events(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<EventClass> Events(string site, int? page, int? pagesize, DateTimeOffset? since)
			{
				throw new NotImplementedException("Requires Authentication");
			}
		}
		public _Events Events{get; private set;}
		public class _Posts
		{
			private SoapiClient _client;
			public _Posts(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<PostClass> Posts(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortPosts? sort)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<PostClass>>("posts", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<PostClass> PostsByIds(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortPostsByIds? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<PostClass>>("posts", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<CommentClass> PostsByIdsComments(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortPostsByIdsComments? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/comments?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<CommentClass>>("posts", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<RevisionClass> PostsByIdsRevisions(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/revisions?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}");
				return _client.Request<ResponseWrapperClass<RevisionClass>>("posts", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<SuggestedEditClass> PostsByIdsSuggestedEdits(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortPostsByIdsSuggestedEdits? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/suggested-edits?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<SuggestedEditClass>>("posts", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Posts Posts{get; private set;}
		public class _Privileges
		{
			private SoapiClient _client;
			public _Privileges(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<PrivilegeClass> Privileges(string site, int? page, int? pagesize)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<PrivilegeClass>>("privileges", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Privileges Privileges{get; private set;}
		public class _Questions
		{
			private SoapiClient _client;
			public _Questions(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<QuestionClass> Questions(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestions? sort, string tagged)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&tagged={tagged}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"tagged",tagged},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> QuestionsByIds(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestionsByIds? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<AnswerClass> QuestionsByIdsAnswers(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestionsByIdsAnswers? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/answers?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<AnswerClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<CommentClass> QuestionsByIdsComments(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestionsByIdsComments? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/comments?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<CommentClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> QuestionsByIdsLinked(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestionsByIdsLinked? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/linked?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> QuestionsByIdsRelated(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestionsByIdsRelated? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/related?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionTimelineClass> QuestionsByIdsTimeline(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/timeline?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}");
				return _client.Request<ResponseWrapperClass<QuestionTimelineClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> QuestionsFeatured(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestionsFeatured? sort, string tagged)
			{
				string uriTemplate = _client.AppendApiKey("/featured?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&tagged={tagged}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"tagged",tagged},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> QuestionsUnanswered(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestionsUnanswered? sort, string tagged)
			{
				string uriTemplate = _client.AppendApiKey("/unanswered?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&tagged={tagged}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"tagged",tagged},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> QuestionsNoAnswers(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortQuestionsNoAnswers? sort, string tagged)
			{
				string uriTemplate = _client.AppendApiKey("/no-answers?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&tagged={tagged}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("questions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"tagged",tagged},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Questions Questions{get; private set;}
		public class _Revisions
		{
			private SoapiClient _client;
			public _Revisions(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<RevisionClass> RevisionsByIds(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}");
				return _client.Request<ResponseWrapperClass<RevisionClass>>("revisions", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Revisions Revisions{get; private set;}
		public class _Search
		{
			private SoapiClient _client;
			public _Search(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<QuestionClass> Search(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortSearch? sort, string tagged, string nottagged, string intitle)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&tagged={tagged}&nottagged={nottagged}&intitle={intitle}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("search", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"tagged",tagged},
					{"nottagged",nottagged},
					{"intitle",intitle},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> Similar(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortSimilar? sort, string tagged, string nottagged, string title)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&tagged={tagged}&nottagged={nottagged}&title={title}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("similar", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"tagged",tagged},
					{"nottagged",nottagged},
					{"title",title},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Search Search{get; private set;}
		public class _Suggested_Edits
		{
			private SoapiClient _client;
			public _Suggested_Edits(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<SuggestedEditClass> SuggestedEdits(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortSuggestedEdits? sort)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<SuggestedEditClass>>("suggested-edits", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<SuggestedEditClass> SuggestedEditsByIds(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortSuggestedEditsByIds? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<SuggestedEditClass>>("suggested-edits", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Suggested_Edits Suggested_Edits{get; private set;}
		public class _Info
		{
			private SoapiClient _client;
			public _Info(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<InfoClass> Info(string site)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}");
				return _client.Request<ResponseWrapperClass<InfoClass>>("info", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Info Info{get; private set;}
		public class _Tags
		{
			private SoapiClient _client;
			public _Tags(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<TagClass> Tags(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortTags? sort, string inname)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&inname={inname}");
				return _client.Request<ResponseWrapperClass<TagClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"inname",inname},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagClass> TagsByTagsInfo(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortTagsByTagsInfo? sort, string tags)
			{
				string uriTemplate = _client.AppendApiKey("/{tags}/info?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<TagClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"tags",tags},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagClass> TagsModeratorOnly(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortTagsModeratorOnly? sort, string inname)
			{
				string uriTemplate = _client.AppendApiKey("/moderator-only?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&inname={inname}");
				return _client.Request<ResponseWrapperClass<TagClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"inname",inname},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagClass> TagsRequired(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortTagsRequired? sort, string inname)
			{
				string uriTemplate = _client.AppendApiKey("/required?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&inname={inname}");
				return _client.Request<ResponseWrapperClass<TagClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"inname",inname},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagSynonymClass> TagsSynonyms(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortTagsSynonyms? sort)
			{
				string uriTemplate = _client.AppendApiKey("/synonyms?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<TagSynonymClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> TagsByTagsFaq(string site, int? page, int? pagesize, string tags)
			{
				string uriTemplate = _client.AppendApiKey("/{tags}/faq?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"tags",tags},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagClass> TagsByTagsRelated(string site, int? page, int? pagesize, string tags)
			{
				string uriTemplate = _client.AppendApiKey("/{tags}/related?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<TagClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"tags",tags},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagSynonymClass> TagsByTagsSynonyms(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortTagsByTagsSynonyms? sort, string tags)
			{
				string uriTemplate = _client.AppendApiKey("/{tags}/synonyms?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<TagSynonymClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"tags",tags},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagScoreClass> TagsByTagTopAnswerersByPeriod(string site, int? page, int? pagesize, string tag, Period period)
			{
				string uriTemplate = _client.AppendApiKey("/{tag}/top-answerers/{period}?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<TagScoreClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"tag",tag},
					{"period",period},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagScoreClass> TagsByTagTopAskersByPeriod(string site, int? page, int? pagesize, string tag, Period period)
			{
				string uriTemplate = _client.AppendApiKey("/{tag}/top-askers/{period}?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<TagScoreClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"tag",tag},
					{"period",period},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagWikiClass> TagsByTagsWikis(string site, int? page, int? pagesize, string tags)
			{
				string uriTemplate = _client.AppendApiKey("/{tags}/wikis?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<TagWikiClass>>("tags", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"tags",tags},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Tags Tags{get; private set;}
		public class _Users
		{
			private SoapiClient _client;
			public _Users(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<UserClass> Users(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsers? sort, string inname)
			{
				string uriTemplate = _client.AppendApiKey("?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}&inname={inname}");
				return _client.Request<ResponseWrapperClass<UserClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"inname",inname},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<UserClass> UsersByIds(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIds? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<UserClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<AnswerClass> UsersByIdsAnswers(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsAnswers? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/answers?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<AnswerClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<BadgeClass> UsersByIdsBadges(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsBadges? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/badges?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<BadgeClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<CommentClass> UsersByIdsComments(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsComments? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/comments?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<CommentClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<CommentClass> UsersByIdsCommentsToId(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsCommentsToId? sort, string ids, int toid)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/comments/{toid}?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<CommentClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
					{"toid",toid},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> UsersByIdsFavorites(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsFavorites? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/favorites?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<CommentClass> UsersByIdsMentioned(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsMentioned? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/mentioned?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<CommentClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<PrivilegeClass> UsersByIdPrivileges(string site, int? page, int? pagesize, int id)
			{
				string uriTemplate = _client.AppendApiKey("/{id}/privileges?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<PrivilegeClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"id",id},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> UsersByIdsQuestions(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsQuestions? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/questions?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> UsersByIdsQuestionsFeatured(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsQuestionsFeatured? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/questions/featured?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> UsersByIdsQuestionsNoAnswers(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsQuestionsNoAnswers? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/questions/no-answers?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> UsersByIdsQuestionsUnaccepted(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsQuestionsUnaccepted? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/questions/unaccepted?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> UsersByIdsQuestionsUnanswered(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsQuestionsUnanswered? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/questions/unanswered?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<ReputationClass> UsersByIdsReputation(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/reputation?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}");
				return _client.Request<ResponseWrapperClass<ReputationClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<SuggestedEditClass> UsersByIdsSuggestedEdits(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsSuggestedEdits? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/suggested-edits?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<SuggestedEditClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TagClass> UsersByIdsTags(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdsTags? sort, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/tags?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<TagClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<AnswerClass> UsersByIdTagsByTagsTopAnswers(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdTagsByTagsTopAnswers? sort, int id, string tags)
			{
				string uriTemplate = _client.AppendApiKey("/{id}/tags/{tags}/top-answers?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<AnswerClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"id",id},
					{"tags",tags},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<QuestionClass> UsersByIdTagsByTagsTopQuestions(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersByIdTagsByTagsTopQuestions? sort, int id, string tags)
			{
				string uriTemplate = _client.AppendApiKey("/{id}/tags/{tags}/top-questions?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<QuestionClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
					{"id",id},
					{"tags",tags},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<UserTimelineClass> UsersByIdsTimeline(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/timeline?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}");
				return _client.Request<ResponseWrapperClass<UserTimelineClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TopTagClass> UsersByIdTopAnswerTags(string site, int? page, int? pagesize, int id)
			{
				string uriTemplate = _client.AppendApiKey("/{id}/top-answer-tags?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<TopTagClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"id",id},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<TopTagClass> UsersByIdTopQuestionTags(string site, int? page, int? pagesize, int id)
			{
				string uriTemplate = _client.AppendApiKey("/{id}/top-question-tags?site={site}&page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<TopTagClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"id",id},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<AnswerClass> UsersModerators(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersModerators? sort)
			{
				string uriTemplate = _client.AppendApiKey("/moderators?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<AnswerClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<UserClass> UsersModeratorsElected(string site, int? page, int? pagesize, DateTimeOffset? fromdate, DateTimeOffset? todate, Order? order, object min, object max, SortUsersModeratorsElected? sort)
			{
				string uriTemplate = _client.AppendApiKey("/moderators/elected?site={site}&page={page}&pagesize={pagesize}&fromdate={fromdate}&todate={todate}&order={order}&min={min}&max={max}&sort={sort}");
				return _client.Request<ResponseWrapperClass<UserClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"site",site},
					{"page",page},
					{"pagesize",pagesize},
					{"fromdate",fromdate},
					{"todate",todate},
					{"order",order},
					{"min",min},
					{"max",max},
					{"sort",sort},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<InboxItemClass> UsersByIdInbox(string site, int? page, int? pagesize, int id)
			{
				throw new NotImplementedException("Requires Authentication");
			}
			public ResponseWrapperClass<InboxItemClass> UsersByIdInboxUnread(string site, int? page, int? pagesize, int id, DateTimeOffset? since)
			{
				throw new NotImplementedException("Requires Authentication");
			}
			public ResponseWrapperClass<NetworkUserClass> UsersByIdAssociated(int? page, int? pagesize, string ids)
			{
				string uriTemplate = _client.AppendApiKey("/{ids}/associated?page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<NetworkUserClass>>("users", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"page",page},
					{"pagesize",pagesize},
					{"ids",ids},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Users Users{get; private set;}
		public class _Access_Tokens
		{
			private SoapiClient _client;
			public _Access_Tokens(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<AccessTokenClass> AccessTokensInvalidate(int? page, int? pagesize, string accessTokens)
			{
				string uriTemplate = _client.AppendApiKey("/{accessTokens}/invalidate?page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<AccessTokenClass>>("access-tokens", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"page",page},
					{"pagesize",pagesize},
					{"accessTokens",accessTokens},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public ResponseWrapperClass<AccessTokenClass> AccessTokens(int? page, int? pagesize, string accessTokens)
			{
				string uriTemplate = _client.AppendApiKey("/{accessTokens}?page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<AccessTokenClass>>("access-tokens", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"page",page},
					{"pagesize",pagesize},
					{"accessTokens",accessTokens},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Access_Tokens Access_Tokens{get; private set;}
		public class _Applications
		{
			private SoapiClient _client;
			public _Applications(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<AccessTokenClass> AppsDeAuthenticate(int? page, int? pagesize, string accessTokens)
			{
				string uriTemplate = _client.AppendApiKey("/{accessTokens}/de-authenticate?page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<AccessTokenClass>>("apps", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"page",page},
					{"pagesize",pagesize},
					{"accessTokens",accessTokens},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Applications Applications{get; private set;}
		public class _Errors
		{
			private SoapiClient _client;
			public _Errors(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<ErrorClass> Errors(int? page, int? pagesize)
			{
				string uriTemplate = _client.AppendApiKey("?page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<ErrorClass>>("errors", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"page",page},
					{"pagesize",pagesize},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
			public void ErrorsById(int id)
			{
				string uriTemplate = _client.AppendApiKey("/{id}");
				 _client.Request<object>("errors", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"id",id},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Errors Errors{get; private set;}
		public class _Filters
		{
			private SoapiClient _client;
			public _Filters(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<FilterClass> FiltersCreate(string include, string exclude, string @base, bool? @unsafe)
			{
				string uriTemplate = _client.AppendApiKey("/create");
				return _client.Request<ResponseWrapperClass<FilterClass>>("filters", uriTemplate , "POST",
				new Dictionary<string, object>
				{
					{"include",include},
					{"exclude",exclude},
					{"base",@base},
					{"unsafe",@unsafe},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.FORM);
			}
			public ResponseWrapperClass<FilterClass> Filters(string filters)
			{
				string uriTemplate = _client.AppendApiKey("/{filters}");
				return _client.Request<ResponseWrapperClass<FilterClass>>("filters", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"filters",filters},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Filters Filters{get; private set;}
		public class _Inbox
		{
			private SoapiClient _client;
			public _Inbox(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<InboxItemClass> Inbox(int? page, int? pagesize)
			{
				throw new NotImplementedException("Requires Authentication");
			}
			public ResponseWrapperClass<InboxItemClass> InboxUnread(int? page, int? pagesize, DateTimeOffset? since)
			{
				throw new NotImplementedException("Requires Authentication");
			}
		}
		public _Inbox Inbox{get; private set;}
		public class _Sites
		{
			private SoapiClient _client;
			public _Sites(SoapiClient client)
			{
				_client=client;
			}
			public ResponseWrapperClass<SiteClass> Sites(int? page, int? pagesize)
			{
				string uriTemplate = _client.AppendApiKey("?page={page}&pagesize={pagesize}");
				return _client.Request<ResponseWrapperClass<SiteClass>>("sites", uriTemplate , "GET",
				new Dictionary<string, object>
				{
					{"page",page},
					{"pagesize",pagesize},
				}
				, TimeSpan.FromMilliseconds(360000), "default",ContentType.JSON);
			}
		}
		public _Sites Sites{get; private set;}
	}
}
