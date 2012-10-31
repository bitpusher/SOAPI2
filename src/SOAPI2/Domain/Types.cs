using System;
using Newtonsoft.Json;
using SOAPI2.Converters;

namespace SOAPI2.Domain
{

	public class AnswerObject{

		[JsonProperty("answer_id")]
		public int AnswerId {get;set;}

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonProperty("comments")]
		public CommentObject[] Comments {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("community_owned_date")]
		public DateTime? CommunityOwnedDate {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("down_vote_count")]
		public int DownVoteCount {get;set;}

		[JsonProperty("is_accepted")]
		public bool IsAccepted {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_activity_date")]
		public DateTime LastActivityDate {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_edit_date")]
		public DateTime? LastEditDate {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("locked_date")]
		public DateTime? LockedDate {get;set;}

		[JsonProperty("owner")]
		public ShallowUserObject Owner {get;set;}

		[JsonProperty("question_id")]
		public int QuestionId {get;set;}

		[JsonProperty("score")]
		public int Score {get;set;}

		[JsonProperty("tags")]
		public string[] Tags {get;set;}

		[JsonProperty("title")]
		public string Title {get;set;}

		[JsonProperty("up_vote_count")]
		public int UpVoteCount {get;set;}

	}

	public class CommentObject{

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonProperty("body_markdown")]
		public string BodyMarkdown {get;set;}

		[JsonProperty("comment_id")]
		public int CommentId {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("edited")]
		public bool Edited {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonProperty("owner")]
		public ShallowUserObject Owner {get;set;}

		[JsonProperty("post_id")]
		public int PostId {get;set;}

		[JsonProperty("post_type")]
		public string PostType {get;set;}

		[JsonProperty("reply_to_user")]
		public ShallowUserObject ReplyToUser {get;set;}

		[JsonProperty("score")]
		public int Score {get;set;}

	}

	public class BadgeObject{

		[JsonProperty("award_count")]
		public int AwardCount {get;set;}

		[JsonProperty("badge_id")]
		public int BadgeId {get;set;}

		[JsonProperty("badge_type")]
		public string BadgeType {get;set;}

		[JsonProperty("description")]
		public string Description {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonProperty("name")]
		public string Name {get;set;}

		[JsonProperty("rank")]
		public string Rank {get;set;}

		[JsonProperty("user")]
		public ShallowUserObject User {get;set;}

	}

	public class EventObject{

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("event_id")]
		public int EventId {get;set;}

		[JsonProperty("event_type")]
		public string EventType {get;set;}

		[JsonProperty("excerpt")]
		public string Excerpt {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

	}

	public class InfoObject{

		[JsonProperty("answers_per_minute")]
		public decimal AnswersPerMinute {get;set;}

		[JsonProperty("api_revision")]
		public string ApiRevision {get;set;}

		[JsonProperty("badges_per_minute")]
		public decimal BadgesPerMinute {get;set;}

		[JsonProperty("new_active_users")]
		public int NewActiveUsers {get;set;}

		[JsonProperty("questions_per_minute")]
		public decimal QuestionsPerMinute {get;set;}

		[JsonProperty("site")]
		public SiteObject Site {get;set;}

		[JsonProperty("total_accepted")]
		public int TotalAccepted {get;set;}

		[JsonProperty("total_answers")]
		public int TotalAnswers {get;set;}

		[JsonProperty("total_badges")]
		public int TotalBadges {get;set;}

		[JsonProperty("total_comments")]
		public int TotalComments {get;set;}

		[JsonProperty("total_questions")]
		public int TotalQuestions {get;set;}

		[JsonProperty("total_unanswered")]
		public int TotalUnanswered {get;set;}

		[JsonProperty("total_users")]
		public int TotalUsers {get;set;}

		[JsonProperty("total_votes")]
		public int TotalVotes {get;set;}

	}

	public class PostObject{

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonProperty("comments")]
		public CommentObject[] Comments {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("down_vote_count")]
		public int DownVoteCount {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_activity_date")]
		public DateTime LastActivityDate {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_edit_date")]
		public DateTime? LastEditDate {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonProperty("owner")]
		public ShallowUserObject Owner {get;set;}

		[JsonProperty("post_id")]
		public int PostId {get;set;}

		[JsonProperty("post_type")]
		public string PostType {get;set;}

		[JsonProperty("score")]
		public int Score {get;set;}

		[JsonProperty("up_vote_count")]
		public int UpVoteCount {get;set;}

	}

	public class RevisionObject{

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonProperty("comment")]
		public string Comment {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("is_rollback")]
		public bool IsRollback {get;set;}

		[JsonProperty("last_body")]
		public string LastBody {get;set;}

		[JsonProperty("last_tags")]
		public string[] LastTags {get;set;}

		[JsonProperty("last_title")]
		public string LastTitle {get;set;}

		[JsonProperty("post_id")]
		public int PostId {get;set;}

		[JsonProperty("post_type")]
		public string PostType {get;set;}

		[JsonProperty("revision_guid")]
		public string RevisionGuid {get;set;}

		[JsonProperty("revision_number")]
		public int RevisionNumber {get;set;}

		[JsonProperty("revision_type")]
		public string RevisionType {get;set;}

		[JsonProperty("set_community_wiki")]
		public bool SetCommunityWiki {get;set;}

		[JsonProperty("tags")]
		public string[] Tags {get;set;}

		[JsonProperty("title")]
		public string Title {get;set;}

		[JsonProperty("user")]
		public ShallowUserObject User {get;set;}

	}

	public class SuggestedEditObject{

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("approval_date")]
		public DateTime? ApprovalDate {get;set;}

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonProperty("comment")]
		public string Comment {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("post_id")]
		public int PostId {get;set;}

		[JsonProperty("post_type")]
		public string PostType {get;set;}

		[JsonProperty("proposing_user")]
		public ShallowUserObject ProposingUser {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("rejection_date")]
		public DateTime? RejectionDate {get;set;}

		[JsonProperty("suggested_edit_id")]
		public int SuggestedEditId {get;set;}

		[JsonProperty("tags")]
		public string[] Tags {get;set;}

		[JsonProperty("title")]
		public string Title {get;set;}

	}

	public class PrivilegeObject{

		[JsonProperty("description")]
		public string Description {get;set;}

		[JsonProperty("reputation")]
		public int Reputation {get;set;}

		[JsonProperty("short_description")]
		public string ShortDescription {get;set;}

	}

	public class QuestionObject{

		[JsonProperty("accepted_answer_id")]
		public int? AcceptedAnswerId {get;set;}

		[JsonProperty("answer_count")]
		public int AnswerCount {get;set;}

		[JsonProperty("answers")]
		public AnswerObject[] Answers {get;set;}

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonProperty("bounty_amount")]
		public int? BountyAmount {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("bounty_closes_date")]
		public DateTime? BountyClosesDate {get;set;}

		[JsonProperty("close_vote_count")]
		public int CloseVoteCount {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("closed_date")]
		public DateTime? ClosedDate {get;set;}

		[JsonProperty("closed_reason")]
		public string ClosedReason {get;set;}

		[JsonProperty("comments")]
		public CommentObject[] Comments {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("community_owned_date")]
		public DateTime? CommunityOwnedDate {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("delete_vote_count")]
		public int DeleteVoteCount {get;set;}

		[JsonProperty("down_vote_count")]
		public int DownVoteCount {get;set;}

		[JsonProperty("favorite_count")]
		public int FavoriteCount {get;set;}

		[JsonProperty("is_answered")]
		public bool IsAnswered {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_activity_date")]
		public DateTime LastActivityDate {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_edit_date")]
		public DateTime? LastEditDate {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("locked_date")]
		public DateTime? LockedDate {get;set;}

		[JsonProperty("migrated_from")]
		public MigrationInfoObject MigratedFrom {get;set;}

		[JsonProperty("migrated_to")]
		public MigrationInfoObject MigratedTo {get;set;}

		[JsonProperty("notice")]
		public NoticeObject Notice {get;set;}

		[JsonProperty("owner")]
		public ShallowUserObject Owner {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("protected_date")]
		public DateTime? ProtectedDate {get;set;}

		[JsonProperty("question_id")]
		public int QuestionId {get;set;}

		[JsonProperty("reopen_vote_count")]
		public int ReopenVoteCount {get;set;}

		[JsonProperty("score")]
		public int Score {get;set;}

		[JsonProperty("tags")]
		public string[] Tags {get;set;}

		[JsonProperty("title")]
		public string Title {get;set;}

		[JsonProperty("up_vote_count")]
		public int UpVoteCount {get;set;}

		[JsonProperty("view_count")]
		public int ViewCount {get;set;}

	}

	public class QuestionTimelineObject{

		[JsonProperty("comment_id")]
		public int? CommentId {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("down_vote_count")]
		public int? DownVoteCount {get;set;}

		[JsonProperty("owner")]
		public ShallowUserObject Owner {get;set;}

		[JsonProperty("post_id")]
		public int? PostId {get;set;}

		[JsonProperty("question_id")]
		public int QuestionId {get;set;}

		[JsonProperty("revision_guid")]
		public string RevisionGuid {get;set;}

		[JsonProperty("timeline_type")]
		public string TimelineType {get;set;}

		[JsonProperty("up_vote_count")]
		public int? UpVoteCount {get;set;}

		[JsonProperty("user")]
		public ShallowUserObject User {get;set;}

	}

	public class TagObject{

		[JsonProperty("count")]
		public int Count {get;set;}

		[JsonProperty("has_synonyms")]
		public bool HasSynonyms {get;set;}

		[JsonProperty("is_moderator_only")]
		public bool IsModeratorOnly {get;set;}

		[JsonProperty("is_required")]
		public bool IsRequired {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_activity_date")]
		public DateTime? LastActivityDate {get;set;}

		[JsonProperty("name")]
		public string Name {get;set;}

		[JsonProperty("user_id")]
		public int? UserId {get;set;}

	}

	public class TagSynonymObject{

		[JsonProperty("applied_count")]
		public int AppliedCount {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("from_tag")]
		public string FromTag {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_applied_date")]
		public DateTime? LastAppliedDate {get;set;}

		[JsonProperty("to_tag")]
		public string ToTag {get;set;}

	}

	public class TagScoreObject{

		[JsonProperty("post_count")]
		public int PostCount {get;set;}

		[JsonProperty("score")]
		public int Score {get;set;}

		[JsonProperty("user")]
		public ShallowUserObject User {get;set;}

	}

	public class TagWikiObject{

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("body_last_edit_date")]
		public DateTime? BodyLastEditDate {get;set;}

		[JsonProperty("excerpt")]
		public string Excerpt {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("excerpt_last_edit_date")]
		public DateTime? ExcerptLastEditDate {get;set;}

		[JsonProperty("last_body_editor")]
		public ShallowUserObject LastBodyEditor {get;set;}

		[JsonProperty("last_excerpt_editor")]
		public ShallowUserObject LastExcerptEditor {get;set;}

		[JsonProperty("tag_name")]
		public string TagName {get;set;}

	}

	public class UserObject{

		[JsonProperty("about_me")]
		public string AboutMe {get;set;}

		[JsonProperty("accept_rate")]
		public int? AcceptRate {get;set;}

		[JsonProperty("account_id")]
		public int AccountId {get;set;}

		[JsonProperty("age")]
		public int? Age {get;set;}

		[JsonProperty("answer_count")]
		public int AnswerCount {get;set;}

		[JsonProperty("badge_counts")]
		public BadgeCountObject BadgeCounts {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("display_name")]
		public string DisplayName {get;set;}

		[JsonProperty("down_vote_count")]
		public int DownVoteCount {get;set;}

		[JsonProperty("is_employee")]
		public bool IsEmployee {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_access_date")]
		public DateTime LastAccessDate {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_modified_date")]
		public DateTime? LastModifiedDate {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonProperty("location")]
		public string Location {get;set;}

		[JsonProperty("profile_image")]
		public string ProfileImage {get;set;}

		[JsonProperty("question_count")]
		public int QuestionCount {get;set;}

		[JsonProperty("reputation")]
		public int Reputation {get;set;}

		[JsonProperty("reputation_change_day")]
		public int ReputationChangeDay {get;set;}

		[JsonProperty("reputation_change_month")]
		public int ReputationChangeMonth {get;set;}

		[JsonProperty("reputation_change_quarter")]
		public int ReputationChangeQuarter {get;set;}

		[JsonProperty("reputation_change_week")]
		public int ReputationChangeWeek {get;set;}

		[JsonProperty("reputation_change_year")]
		public int ReputationChangeYear {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("timed_penalty_date")]
		public DateTime? TimedPenaltyDate {get;set;}

		[JsonProperty("up_vote_count")]
		public int UpVoteCount {get;set;}

		[JsonProperty("user_id")]
		public int UserId {get;set;}

		[JsonProperty("user_type")]
		public string UserType {get;set;}

		[JsonProperty("view_count")]
		public int ViewCount {get;set;}

		[JsonProperty("website_url")]
		public string WebsiteUrl {get;set;}

	}

	public class AccountMergeObject{

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("merge_date")]
		public DateTime MergeDate {get;set;}

		[JsonProperty("new_account_id")]
		public int NewAccountId {get;set;}

		[JsonProperty("old_account_id")]
		public int OldAccountId {get;set;}

	}

	public class NotificationObject{

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("is_unread")]
		public bool IsUnread {get;set;}

		[JsonProperty("notification_type")]
		public string NotificationType {get;set;}

		[JsonProperty("post_id")]
		public int? PostId {get;set;}

		[JsonProperty("site")]
		public SiteObject Site {get;set;}

	}

	public class ReputationObject{

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("on_date")]
		public DateTime OnDate {get;set;}

		[JsonProperty("post_id")]
		public int PostId {get;set;}

		[JsonProperty("post_type")]
		public string PostType {get;set;}

		[JsonProperty("reputation_change")]
		public int ReputationChange {get;set;}

		[JsonProperty("title")]
		public string Title {get;set;}

		[JsonProperty("user_id")]
		public int UserId {get;set;}

		[JsonProperty("vote_type")]
		public string VoteType {get;set;}

	}

	public class ReputationHistoryObject{

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("post_id")]
		public int? PostId {get;set;}

		[JsonProperty("reputation_change")]
		public int ReputationChange {get;set;}

		[JsonProperty("reputation_history_type")]
		public string ReputationHistoryType {get;set;}

		[JsonProperty("user_id")]
		public int UserId {get;set;}

	}

	public class UserTimelineObject{

		[JsonProperty("badge_id")]
		public int? BadgeId {get;set;}

		[JsonProperty("comment_id")]
		public int? CommentId {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("detail")]
		public string Detail {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonProperty("post_id")]
		public int? PostId {get;set;}

		[JsonProperty("post_type")]
		public string PostType {get;set;}

		[JsonProperty("suggested_edit_id")]
		public int? SuggestedEditId {get;set;}

		[JsonProperty("timeline_type")]
		public string TimelineType {get;set;}

		[JsonProperty("title")]
		public string Title {get;set;}

		[JsonProperty("user_id")]
		public int UserId {get;set;}

	}

	public class TopTagObject{

		[JsonProperty("answer_count")]
		public int AnswerCount {get;set;}

		[JsonProperty("answer_score")]
		public int AnswerScore {get;set;}

		[JsonProperty("question_count")]
		public int QuestionCount {get;set;}

		[JsonProperty("question_score")]
		public int QuestionScore {get;set;}

		[JsonProperty("tag_name")]
		public string TagName {get;set;}

		[JsonProperty("user_id")]
		public int UserId {get;set;}

	}

	public class WritePermissionObject{

		[JsonProperty("can_add")]
		public bool CanAdd {get;set;}

		[JsonProperty("can_delete")]
		public bool CanDelete {get;set;}

		[JsonProperty("can_edit")]
		public bool CanEdit {get;set;}

		[JsonProperty("max_daily_actions")]
		public int MaxDailyActions {get;set;}

		[JsonProperty("min_seconds_between_actions")]
		public int MinSecondsBetweenActions {get;set;}

		[JsonProperty("object_type")]
		public string ObjectType {get;set;}

		[JsonProperty("user_id")]
		public int UserId {get;set;}

	}

	public class InboxItemObject{

		[JsonProperty("answer_id")]
		public int? AnswerId {get;set;}

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonProperty("comment_id")]
		public int? CommentId {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("is_unread")]
		public bool IsUnread {get;set;}

		[JsonProperty("item_type")]
		public string ItemType {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonProperty("question_id")]
		public int? QuestionId {get;set;}

		[JsonProperty("site")]
		public SiteObject Site {get;set;}

		[JsonProperty("title")]
		public string Title {get;set;}

	}

	public class AccessTokenObject{

		[JsonProperty("access_token")]
		public string AccessToken {get;set;}

		[JsonProperty("account_id")]
		public int AccountId {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("expires_on_date")]
		public DateTime? ExpiresOnDate {get;set;}

		[JsonProperty("scope")]
		public string[] Scope {get;set;}

	}

	public class ErrorObject{

		[JsonProperty("description")]
		public string Description {get;set;}

		[JsonProperty("error_id")]
		public int ErrorId {get;set;}

		[JsonProperty("error_name")]
		public string ErrorName {get;set;}

	}

	public class FilterObject{

		[JsonProperty("filter")]
		public string Filter {get;set;}

		[JsonProperty("filter_type")]
		public string FilterType {get;set;}

		[JsonProperty("included_fields")]
		public string[] IncludedFields {get;set;}

	}

	public class SiteObject{

		[JsonProperty("aliases")]
		public string[] Aliases {get;set;}

		[JsonProperty("api_site_parameter")]
		public string ApiSiteParameter {get;set;}

		[JsonProperty("audience")]
		public string Audience {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("closed_beta_date")]
		public DateTime? ClosedBetaDate {get;set;}

		[JsonProperty("favicon_url")]
		public string FaviconUrl {get;set;}

		[JsonProperty("high_resolution_icon_url")]
		public string HighResolutionIconUrl {get;set;}

		[JsonProperty("icon_url")]
		public string IconUrl {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("launch_date")]
		public DateTime LaunchDate {get;set;}

		[JsonProperty("logo_url")]
		public string LogoUrl {get;set;}

		[JsonProperty("markdown_extensions")]
		public string[] MarkdownExtensions {get;set;}

		[JsonProperty("name")]
		public string Name {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("open_beta_date")]
		public DateTime? OpenBetaDate {get;set;}

		[JsonProperty("related_sites")]
		public RelatedSiteObject[] RelatedSites {get;set;}

		[JsonProperty("site_state")]
		public string SiteState {get;set;}

		[JsonProperty("site_type")]
		public string SiteType {get;set;}

		[JsonProperty("site_url")]
		public string SiteUrl {get;set;}

		[JsonProperty("styling")]
		public StylingObject Styling {get;set;}

		[JsonProperty("twitter_account")]
		public string TwitterAccount {get;set;}

	}

	public class NetworkUserObject{

		[JsonProperty("account_id")]
		public int AccountId {get;set;}

		[JsonProperty("answer_count")]
		public int AnswerCount {get;set;}

		[JsonProperty("badge_counts")]
		public BadgeCountObject BadgeCounts {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_access_date")]
		public DateTime LastAccessDate {get;set;}

		[JsonProperty("question_count")]
		public int QuestionCount {get;set;}

		[JsonProperty("reputation")]
		public int Reputation {get;set;}

		[JsonProperty("site_name")]
		public string SiteName {get;set;}

		[JsonProperty("site_url")]
		public string SiteUrl {get;set;}

		[JsonProperty("user_id")]
		public int UserId {get;set;}

		[JsonProperty("user_type")]
		public string UserType {get;set;}

	}

	public class ShallowUserObject{

		[JsonProperty("accept_rate")]
		public int? AcceptRate {get;set;}

		[JsonProperty("display_name")]
		public string DisplayName {get;set;}

		[JsonProperty("link")]
		public string Link {get;set;}

		[JsonProperty("profile_image")]
		public string ProfileImage {get;set;}

		[JsonProperty("reputation")]
		public int? Reputation {get;set;}

		[JsonProperty("user_id")]
		public int? UserId {get;set;}

		[JsonProperty("user_type")]
		public string UserType {get;set;}

	}

	public class MigrationInfoObject{

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("on_date")]
		public DateTime OnDate {get;set;}

		[JsonProperty("other_site")]
		public SiteObject OtherSite {get;set;}

		[JsonProperty("question_id")]
		public int QuestionId {get;set;}

	}

	public class NoticeObject{

		[JsonProperty("body")]
		public string Body {get;set;}

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		public DateTime CreationDate {get;set;}

		[JsonProperty("owner_user_id")]
		public int OwnerUserId {get;set;}

	}

	public class BadgeCountObject{

		[JsonProperty("bronze")]
		public int Bronze {get;set;}

		[JsonProperty("gold")]
		public int Gold {get;set;}

		[JsonProperty("silver")]
		public int Silver {get;set;}

	}

	public class RelatedSiteObject{

		[JsonProperty("api_site_parameter")]
		public string ApiSiteParameter {get;set;}

		[JsonProperty("name")]
		public string Name {get;set;}

		[JsonProperty("relation")]
		public string Relation {get;set;}

		[JsonProperty("site_url")]
		public string SiteUrl {get;set;}

	}

	public class StylingObject{

		[JsonProperty("link_color")]
		public string LinkColor {get;set;}

		[JsonProperty("tag_background_color")]
		public string TagBackgroundColor {get;set;}

		[JsonProperty("tag_foreground_color")]
		public string TagForegroundColor {get;set;}

	}
}
