USE [dev99.vjtech.co.uk]
GO
/****** Object:  StoredProcedure [dbo].[OpenUrlRewriter_AddUrlRule]    Script Date: 07/07/2021 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[OpenUrlRewriter_AddUrlRule]

@DateTime                      datetime, 
@UserId                        int,
@RuleType                      int,
@CultureCode                   nvarchar(50)          = null,
@PortalId                      int,
@TabId                         int                   = null,
@Parameters                    nvarchar(255)         = null,
@RemoveTab                     bit,
@RuleAction                    int,	
@Url                           nvarchar(255)         = null,
@RedirectDestination           nvarchar(255)         = null,
@RedirectStatus                int                   = null

as

declare @UrlLogHistory int

insert into OpenUrlRewriter_UrlRule ( 
  DateTime,
  UserId,
  RuleType,
  CultureCode,
  PortalId, 
  TabId,
  Parameters,
  RemoveTab,
  RuleAction,
  Url,
  RedirectDestination,
  RedirectStatus
)
values (
  @DateTime,
  @UserId,
  @RuleType,
  @CultureCode,
  @PortalId, 
  @TabId,
  @Parameters,
  @RemoveTab,
  @RuleAction,
  @Url,
  @RedirectDestination,
  @RedirectStatus
)
SELECT SCOPE_IDENTITY()