/****** Object:  Schema [SystemCenter_admin]    Script Date: 6/15/2021 11:02:35 AM ******/
CREATE SCHEMA [SystemCenter_admin]
GO
/****** Object:  Schema [SystemCenter_user]    Script Date: 6/15/2021 11:02:35 AM ******/
CREATE SCHEMA [SystemCenter_user]
GO
/****** Object:  UserDefinedFunction [dbo].[CleanParam]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****************************************************************************
FUNCTION NAME:    CleanParam
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Strips chars from the string
RETURN VALUES:
string

PARAMETERS:
@Somevalue nvarchar(200)

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/
CREATE function [dbo].[CleanParam](@SomeValue nvarchar(200))
Returns nvarchar(200)
as
begin

return replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(@SomeValue,'''',''),';',''),'--',''),'/*',''),'*/',''),'[',''),']',''),'^',''),'%',''),'_','')


end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_MajorMinorVersionCompare]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE FUNCTION [dbo].[fn_MajorMinorVersionCompare]
  (
      @Version1 nvarchar(25)
     ,@Version2 nvarchar(25)
  )
  RETURNS int
  AS
  BEGIN
    DECLARE
       @Version1Major     bigint
      ,@Version1Minor     bigint
      ,@Version1Build     bigint
      ,@Version1Revision  bigint
      ,@Version2Major     bigint
      ,@Version2Minor     bigint
      ,@Version2Build     bigint
      ,@Version2Revision  bigint
      ,@DotIndex          int
      ,@PreviousDotIndex  int
      ,@i                 int
      ,@j                 int
      ,@vstr              nvarchar(25)
      ,@v                 bigint
      ,@Result            int
      
    SET @Version1 = @Version1 + '.'
    SET @Version2 = @Version2 + '.'
    
    SET @i = 0

    
    WHILE (@i < 2)
    BEGIN
      SET @PreviousDotIndex = 0
      
      SET @j = 0
      
      WHILE (@j < 4)
      BEGIN
        IF (@i = 0)
          SET @DotIndex = CHARINDEX('.', @Version1, @PreviousDotIndex + 1)
        ELSE
          SET @DotIndex = CHARINDEX('.', @Version2, @PreviousDotIndex + 1)
        
        IF (@DotIndex > 0)
        BEGIN
          IF (@i = 0)
          BEGIN
            SET @vstr = SUBSTRING(@Version1, @PreviousDotIndex + 1, @DotIndex - @PreviousDotIndex - 1)
            
            IF (ISNUMERIC(@vstr) = 1)
            BEGIN
              SET @v = CAST(@vstr AS bigint)

              IF (@j = 0) SET @Version1Major = @v
              ELSE IF (@j = 1) SET @Version1Minor = @v
              ELSE IF (@j = 2) SET @Version1Build = @v
              ELSE IF (@j = 3) SET @Version1Revision = @v
            END
          END
          ELSE
          BEGIN
            SET @vstr = SUBSTRING(@Version2, @PreviousDotIndex + 1, @DotIndex - @PreviousDotIndex - 1)

            IF (ISNUMERIC(@vstr) = 1)
            BEGIN
              SET @v = CAST(@vstr AS bigint)
              
              IF (@j = 0) SET @Version2Major = @v
              ELSE IF (@j = 1) SET @Version2Minor = @v
              ELSE IF (@j = 2) SET @Version2Build = @v
              ELSE IF (@j = 3) SET @Version2Revision = @v
            END
          END
        END

        SET @PreviousDotIndex = @DotIndex

        SET @j = @j + 1
      END
      
      SET @i = @i + 1
    END

    SET @Result = 0
      
    IF (@Version1Major > @Version2Major)
      SET @Result = 1
    ELSE IF (@Version1Major < @Version2Major)
      SET @Result = -1
    ELSE IF (@Version1Major = @Version2Major)
    BEGIN
      IF (@Version1Minor > @Version2Minor)
        SET @Result = 1
      ELSE IF (@Version1Minor < @Version2Minor)
        SET @Result = -1
    END

    RETURN @Result
  END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_VersionCompare]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE FUNCTION [dbo].[fn_VersionCompare]
  (
      @Version1 nvarchar(25)
     ,@Version2 nvarchar(25)
  )
  RETURNS int
  AS
  BEGIN
    DECLARE
       @Version1Major     bigint
      ,@Version1Minor     bigint
      ,@Version1Build     bigint
      ,@Version1Revision  bigint
      ,@Version2Major     bigint
      ,@Version2Minor     bigint
      ,@Version2Build     bigint
      ,@Version2Revision  bigint
      ,@DotIndex          int
      ,@PreviousDotIndex  int
      ,@i                 int
      ,@j                 int
      ,@vstr              nvarchar(25)
      ,@v                 bigint
      ,@Result            int
      
    SET @Version1 = @Version1 + '.'
    SET @Version2 = @Version2 + '.'
    
    SET @i = 0

    
    WHILE (@i < 2)
    BEGIN
      SET @PreviousDotIndex = 0
      
      SET @j = 0
      
      WHILE (@j < 4)
      BEGIN
        IF (@i = 0)
          SET @DotIndex = CHARINDEX('.', @Version1, @PreviousDotIndex + 1)
        ELSE
          SET @DotIndex = CHARINDEX('.', @Version2, @PreviousDotIndex + 1)
        
        IF (@DotIndex > 0)
        BEGIN
          IF (@i = 0)
          BEGIN
            SET @vstr = SUBSTRING(@Version1, @PreviousDotIndex + 1, @DotIndex - @PreviousDotIndex - 1)
            
            IF (ISNUMERIC(@vstr) = 1)
            BEGIN
              SET @v = CAST(@vstr AS bigint)

              IF (@j = 0) SET @Version1Major = @v
              ELSE IF (@j = 1) SET @Version1Minor = @v
              ELSE IF (@j = 2) SET @Version1Build = @v
              ELSE IF (@j = 3) SET @Version1Revision = @v
            END
          END
          ELSE
          BEGIN
            SET @vstr = SUBSTRING(@Version2, @PreviousDotIndex + 1, @DotIndex - @PreviousDotIndex - 1)

            IF (ISNUMERIC(@vstr) = 1)
            BEGIN
              SET @v = CAST(@vstr AS bigint)
              
              IF (@j = 0) SET @Version2Major = @v
              ELSE IF (@j = 1) SET @Version2Minor = @v
              ELSE IF (@j = 2) SET @Version2Build = @v
              ELSE IF (@j = 3) SET @Version2Revision = @v
            END
          END
        END

        SET @PreviousDotIndex = @DotIndex

        SET @j = @j + 1
      END
      
      SET @i = @i + 1
    END
      
    IF (@Version1Major > @Version2Major)
      SET @Result = 1
    ELSE IF (@Version1Major < @Version2Major)
      SET @Result = -1
    ELSE IF (@Version1Major = @Version2Major)
    BEGIN
      IF (@Version1Minor > @Version2Minor)
        SET @Result = 1
      ELSE IF (@Version1Minor < @Version2Minor)
        SET @Result = -1
      ELSE IF (@Version1Minor = @Version2Minor)
      BEGIN
        IF (@Version1Build > @Version2Build)
          SET @Result = 1
        ELSE IF (@Version1Build < @Version2Build)
          SET @Result = -1
        ELSE IF (@Version1Build = @Version2Build)
        BEGIN
          IF (@Version1Revision > @Version2Revision)
            SET @Result = 1
          ELSE IF (@Version1Revision < @Version2Revision)
            SET @Result = -1
          ELSE IF (@Version1Revision = @Version2Revision)
            SET @Result = 0
        END
      END
    END

    RETURN @Result
  END
GO
/****** Object:  UserDefinedFunction [dbo].[FormatDateShort]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************************************
FUNCTION NAME:    FormatDateShort
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Formats datetime as MMM dd, yyyy

RETURN VALUES:
string

PARAMETERS:
@SomeDate datetime

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/
CREATE function [dbo].[FormatDateShort](@SomeDate datetime)
Returns varchar(30)
as
begin

declare @FormattedDate varchar(30)

select @FormattedDate=substring(DateName(mm,@SomeDate),1,3) + ' ' + convert(varchar(2),day(@SomeDate)) + ', ' + convert(varchar(4),Year(@SomeDate))

return @FormattedDate
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetCharTableFromString]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************************************
FUNCTION NAME:    GetCharTableFromString
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Split string

RETURN VALUES:
Table

PARAMETERS:
@Input nvarchar(2000) - string to be splited
@Delimiter nchar(1) - delimiter

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/

CREATE FUNCTION [dbo].[GetCharTableFromString](@Input nvarchar(2000) ,@Delimiter nchar(1))
RETURNS @OutTable TABLE ( [CNT] INT IDENTITY (1, 1) NOT NULL ,[Token]  nvarchar(200)  NOT NULL ) 
AS
BEGIN

	DECLARE @Pos as INT
	DECLARE @InputLength INT
	DECLARE @OneToken nvarchar(200)	
	
	--parse  list and stick it into temptable
	
	set @Pos = CHARINDEX(@Delimiter, @Input, 1)
	while @Pos>0
		BEGIN
			Set @Input=LTRIM(RTRIM(@Input))	
			Set @InputLength=LEN(@Input)	
			Set @OneToken =  SUBSTRING(@Input, 1, @Pos-1)
		
			insert @OutTable values (LTRIM(RTRIM(@Onetoken)))
			SET @OneToken =NULL --to ignore empty delimiter strings
			Set @Input =  SUBSTRING(@Input,  @Pos+1,@InputLength-@Pos )
			Set @Input = LTRIM(RTRIM(@Input))			
		
			Set @Pos = CHARINDEX(@Delimiter, @Input, 1)
		END
	
	
	insert @OutTable  values  (@Input)

	
	RETURN 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetPackLangList]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************************************
FUNCTION NAME:    GetPackLangList
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Concatenates list of languages for which localized version exists for provided packid

RETURN VALUES:
string

PARAMETERS:
@PackID int,
@IsPreview bit

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/
CREATE function [dbo].[GetPackLangList](@PackId int,@IsPreview bit )
Returns varchar(2000)
as

begin

declare @PackLangList varchar(2000)
select @PackLangList=coalesce(@PackLangList + ', ','') + LanguageName from PackLocalizedData join [language] on lcid_FK=lcid where PackIDLoc=@PackId and IsPreviewLoc=@IsPreview 
return isnull(@PackLangList,'')
end
GO
/****** Object:  UserDefinedFunction [dbo].[ParseStringIntoTokens]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************************************
FUNCTION NAME:    ParseStringIntoTokens
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Parse provided string into tokens (token is either word or group of words surrounded by quotes)
RETURN VALUES:
string

PARAMETERS:
@StringToParse nvarchar(2000)

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/
CREATE FUNCTION [dbo].[ParseStringIntoTokens](@StringToParse nvarchar(2000) )
RETURNS nvarchar(2200) 
AS
BEGIN
declare @cnt int,@I int,@StringToReturn nvarchar(220)
declare @wasQuotes bit
set @wasQuotes=0
set @StringToReturn=''

set @cnt=len(@StringToParse)
set @i=1
if @cnt>0
begin
	while @i<=@cnt
	begin
		if substring(@StringToParse,@I,1)<>'"' and substring(@StringToParse,@I,1)<>' '
		begin
			set @StringToReturn=@StringToReturn + substring(@StringToParse,@I,1)
		end
		else
		begin
			if substring(@StringToParse,@I,1)=' ' 
			begin
				if @wasQuotes=0
					set @StringToReturn=@StringToReturn+'^'
				else
					set @StringToReturn=@StringToReturn + substring(@StringToParse,@I,1)
			end
			else
			begin
				if @wasQuotes=0
				begin
					set @wasQuotes=1
					set @StringToReturn=@StringToReturn+'^'
				end
				else
				begin
					set @wasQuotes=0
					set @StringToReturn=@StringToReturn+'^'	
				end
			end
		end
		set @i=@i+1
	end

end 
return replace(@StringToReturn,'^^','^')
	
END
GO
/****** Object:  Table [dbo].[CatalogCategory]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogCategory](
	[CatalogItemId] [int] NOT NULL,
	[ParentCategoryId] [int] NOT NULL,
	[DefaultGuideUriText] [nvarchar](1024) NOT NULL,
	[DefaultGuideUriLink] [nvarchar](max) NOT NULL,
	[SortIndex] [int] NOT NULL,
 CONSTRAINT [PK_CatalogCategory] PRIMARY KEY CLUSTERED 
(
	[CatalogItemId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogCategoryLocalized]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogCategoryLocalized](
	[CatalogItemId] [int] NOT NULL,
	[ThreeLetterLanguageCode] [char](3) NOT NULL,
	[LocalizedGuideUriText] [nvarchar](1024) NULL,
	[LocalizedGuideUriLink] [nvarchar](1024) NULL,
 CONSTRAINT [PK_CatalogCategoryLocalized] PRIMARY KEY CLUSTERED 
(
	[CatalogItemId] ASC,
	[ThreeLetterLanguageCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogItem]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogItem](
	[CatalogItemId] [int] IDENTITY(1,1) NOT NULL,
	[IsManagementPack] [bit] NOT NULL,
	[IsCategory] [bit] NOT NULL,
	[PublishedInd] [bit] NOT NULL,
	[DefaultDisplayName] [nvarchar](1024) NOT NULL,
	[DefaultDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CatalogItem] PRIMARY KEY CLUSTERED 
(
	[CatalogItemId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogItemLocalized]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogItemLocalized](
	[CatalogItemId] [int] NOT NULL,
	[ThreeLetterLanguageCode] [char](3) NOT NULL,
	[LocalizedDisplayName] [nvarchar](1024) NULL,
	[LocalizedDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_CatalogItemLocalized] PRIMARY KEY CLUSTERED 
(
	[CatalogItemId] ASC,
	[ThreeLetterLanguageCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogManagementPack]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogManagementPack](
	[CatalogItemId] [int] NOT NULL,
	[VersionIndependentGuid] [uniqueidentifier] NOT NULL,
	[Version] [nvarchar](25) NOT NULL,
	[SystemName] [nvarchar](256) NOT NULL,
	[PublicKey] [varchar](32) NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[VendorId] [int] NOT NULL,
	[DownloadUri] [nvarchar](1024) NOT NULL,
	[DefaultKnowledge] [nvarchar](max) NOT NULL,
	[EulaInd] [bit] NOT NULL,
	[DefaultEula] [nvarchar](max) NULL,
	[SecurityInd] [bit] NOT NULL,
	[DefaultThirdPartyDownloadText] [nvarchar](1024) NOT NULL,
	[DefaultThirdPartyDownloadLink] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_CatalogManagementPack] PRIMARY KEY CLUSTERED 
(
	[CatalogItemId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UN_CatalogManagementPack_Guid_Version] UNIQUE NONCLUSTERED 
(
	[VersionIndependentGuid] ASC,
	[Version] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogManagementPackCategory]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogManagementPackCategory](
	[ManagementPackCatalogItemId] [int] NOT NULL,
	[CategoryCatalogItemId] [int] NOT NULL,
 CONSTRAINT [PK_CatalogManagementPackCategory] PRIMARY KEY CLUSTERED 
(
	[ManagementPackCatalogItemId] ASC,
	[CategoryCatalogItemId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogManagementPackDependency]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogManagementPackDependency](
	[ManagementPackCatalogItemId] [int] NOT NULL,
	[DependentMpVersionIndependentGuid] [uniqueidentifier] NOT NULL,
	[DependentMpVersion] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_CatalogManagementPackDependency] PRIMARY KEY CLUSTERED 
(
	[ManagementPackCatalogItemId] ASC,
	[DependentMpVersionIndependentGuid] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogManagementPackLocalized]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogManagementPackLocalized](
	[CatalogItemId] [int] NOT NULL,
	[ThreeLetterLanguageCode] [char](3) NOT NULL,
	[LocalizedKnowledge] [nvarchar](max) NULL,
	[LocalizedEula] [nvarchar](max) NULL,
	[LocalizedThirdPartyDownloadText] [nvarchar](1024) NOT NULL,
	[LocalizedThirdPartyDownloadLink] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_CatalogManagementPackLocalized] PRIMARY KEY CLUSTERED 
(
	[CatalogItemId] ASC,
	[ThreeLetterLanguageCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogProduct]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogProduct](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](1024) NOT NULL,
	[ProductVersion] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_CatalogProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogProductCatalogItem]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogProductCatalogItem](
	[ProductId] [int] NOT NULL,
	[CatalogItemId] [int] NOT NULL,
 CONSTRAINT [PK_CatalogProductCatalogItem] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CatalogItemId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogVendor]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogVendor](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[DefaultVendorName] [nvarchar](1024) NOT NULL,
	[DefaultVendorLink] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_CatalogVendor] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogVendorLocalized]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogVendorLocalized](
	[VendorId] [int] NOT NULL,
	[ThreeLetterLanguageCode] [char](3) NOT NULL,
	[LocalizedVendorName] [nvarchar](1024) NULL,
	[LocalizedVendorLink] [nvarchar](1024) NULL,
 CONSTRAINT [PK_CatalogVendorLocalized] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC,
	[ThreeLetterLanguageCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[SRVID] [int] NOT NULL,
	[ErrSource] [varchar](500) NOT NULL,
	[ErrMessage] [varchar](1000) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorID] ASC,
	[SRVID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LCID] [int] NOT NULL,
	[LanguageName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LCID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pack]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pack](
	[PackID] [int] NOT NULL,
	[IsPreview] [tinyint] NOT NULL,
	[PackName] [nvarchar](100) NOT NULL,
	[ApplicationName] [nvarchar](100) NOT NULL,
	[DownloadURL] [varchar](500) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[VendorName] [nvarchar](100) NOT NULL,
	[VendorURL] [varchar](500) NOT NULL,
	[LastUpdatedDateTime] [datetime] NOT NULL,
	[IsPackActive] [bit] NOT NULL,
	[LastEditedDateTime] [datetime] NOT NULL,
	[LastEditedBy] [varchar](30) NOT NULL,
	[PublishedDateTime] [datetime] NOT NULL,
	[PublishedBy] [varchar](30) NOT NULL,
	[PackVersion] [nvarchar](40) NULL,
 CONSTRAINT [PK_Pack] PRIMARY KEY CLUSTERED 
(
	[PackID] ASC,
	[IsPreview] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackFeedback]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackFeedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[SRVID] [int] NOT NULL,
	[PackID_Feedback] [int] NOT NULL,
	[ProductID_Feedback] [smallint] NOT NULL,
	[TimeOfUsage] [char](5) NOT NULL,
	[MeetNeedsGrade] [tinyint] NOT NULL,
	[SatisfactionGrade] [tinyint] NOT NULL,
	[Reason] [nvarchar](2000) NULL,
	[Improvements] [nvarchar](2000) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[HexPUID] [varchar](25) NOT NULL,
 CONSTRAINT [PK_PackFeedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC,
	[SRVID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackLocalizedData]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackLocalizedData](
	[PackIDLoc] [int] NOT NULL,
	[LCID_FK] [int] NOT NULL,
	[IsPreviewLoc] [tinyint] NOT NULL,
	[PackNameLoc] [nvarchar](100) NOT NULL,
	[ApplicationNameLoc] [nvarchar](100) NOT NULL,
	[DownloadURLLoc] [varchar](500) NOT NULL,
	[DescriptionLoc] [nvarchar](2000) NOT NULL,
	[LastUpdatedDateTimeLoc] [datetime] NOT NULL,
	[LastEditedDateTime] [datetime] NOT NULL,
	[LastEditedBy] [varchar](30) NOT NULL,
	[PackVersionLoc] [nvarchar](40) NULL,
 CONSTRAINT [PK_PackLocalizedData_1] PRIMARY KEY CLUSTERED 
(
	[PackIDLoc] ASC,
	[LCID_FK] ASC,
	[IsPreviewLoc] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackProducts]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackProducts](
	[PackIDProd] [int] NOT NULL,
	[ProductID_FK] [smallint] NOT NULL,
	[IsPreviewProd] [tinyint] NOT NULL,
 CONSTRAINT [PK_PackProducts_1] PRIMARY KEY CLUSTERED 
(
	[PackIDProd] ASC,
	[ProductID_FK] ASC,
	[IsPreviewProd] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [smallint] NOT NULL,
	[ProductName] [varchar](200) NOT NULL,
	[SortOrder] [tinyint] NOT NULL,
	[IsProductActive] [bit] NOT NULL,
 CONSTRAINT [PK__Product__7E6CC920] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemCenter]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemCenter](
	[CenterID] [smallint] NOT NULL,
	[CenterName] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_SystemCenter] PRIMARY KEY CLUSTERED 
(
	[CenterID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemCenterProducts]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemCenterProducts](
	[CenterID_FK] [smallint] NOT NULL,
	[ProductID_FK] [smallint] NOT NULL,
	[IsDefaultProduct] [bit] NOT NULL,
 CONSTRAINT [PK_SystemCenterProducts] PRIMARY KEY CLUSTERED 
(
	[CenterID_FK] ASC,
	[ProductID_FK] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CatalogCategory] ADD  DEFAULT ((0)) FOR [SortIndex]
GO
ALTER TABLE [dbo].[CatalogItem] ADD  DEFAULT ((0)) FOR [IsManagementPack]
GO
ALTER TABLE [dbo].[CatalogItem] ADD  DEFAULT ((1)) FOR [IsCategory]
GO
ALTER TABLE [dbo].[CatalogItem] ADD  DEFAULT ((0)) FOR [PublishedInd]
GO
ALTER TABLE [dbo].[CatalogManagementPack] ADD  DEFAULT (getutcdate()) FOR [ReleaseDate]
GO
ALTER TABLE [dbo].[CatalogManagementPack] ADD  DEFAULT ((0)) FOR [EulaInd]
GO
ALTER TABLE [dbo].[CatalogManagementPack] ADD  DEFAULT ((0)) FOR [SecurityInd]
GO
ALTER TABLE [dbo].[CatalogManagementPack] ADD  DEFAULT ('') FOR [DefaultThirdPartyDownloadText]
GO
ALTER TABLE [dbo].[CatalogManagementPack] ADD  DEFAULT ('') FOR [DefaultThirdPartyDownloadLink]
GO
ALTER TABLE [dbo].[CatalogManagementPackLocalized] ADD  DEFAULT ('') FOR [LocalizedThirdPartyDownloadText]
GO
ALTER TABLE [dbo].[CatalogManagementPackLocalized] ADD  DEFAULT ('') FOR [LocalizedThirdPartyDownloadLink]
GO
ALTER TABLE [dbo].[ErrorLog] ADD  DEFAULT (right(@@servername,(2))) FOR [SRVID]
GO
ALTER TABLE [dbo].[Pack] ADD  CONSTRAINT [DF_Pack_IsPreview]  DEFAULT ((1)) FOR [IsPreview]
GO
ALTER TABLE [dbo].[Pack] ADD  CONSTRAINT [DF__Pack__Descriptio__2A4B4B5E]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Pack] ADD  CONSTRAINT [DF__Pack__VendorURL__2B3F6F97]  DEFAULT ('') FOR [VendorURL]
GO
ALTER TABLE [dbo].[Pack] ADD  CONSTRAINT [DF_Pack_IsPackActive]  DEFAULT ((1)) FOR [IsPackActive]
GO
ALTER TABLE [dbo].[Pack] ADD  CONSTRAINT [DF_Pack_DataLCID]  DEFAULT ((1033)) FOR [PublishedDateTime]
GO
ALTER TABLE [dbo].[PackFeedback] ADD  CONSTRAINT [DF__PackFeedb__SRVID__286302EC]  DEFAULT (right(@@servername,(2))) FOR [SRVID]
GO
ALTER TABLE [dbo].[PackFeedback] ADD  CONSTRAINT [DF_PackFeedback_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[PackLocalizedData] ADD  CONSTRAINT [DF_PackLocalizedData_IsPreview]  DEFAULT ((1)) FOR [IsPreviewLoc]
GO
ALTER TABLE [dbo].[PackLocalizedData] ADD  CONSTRAINT [DF__PackLocal__Descr__0BC6C43E]  DEFAULT ('') FOR [DescriptionLoc]
GO
ALTER TABLE [dbo].[PackProducts] ADD  CONSTRAINT [DF_PackProducts_IsPreview]  DEFAULT ((1)) FOR [IsPreviewProd]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_IsActive]  DEFAULT ((1)) FOR [IsProductActive]
GO
ALTER TABLE [dbo].[SystemCenterProducts] ADD  CONSTRAINT [DF_SystemCenterProducts_IsDefaultProduct]  DEFAULT ((0)) FOR [IsDefaultProduct]
GO
ALTER TABLE [dbo].[CatalogCategory]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogItem_CatalogCategory] FOREIGN KEY([CatalogItemId])
REFERENCES [dbo].[CatalogItem] ([CatalogItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogCategory] CHECK CONSTRAINT [FK_CatalogItem_CatalogCategory]
GO
ALTER TABLE [dbo].[CatalogCategoryLocalized]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogCategory_CatalogCategoryLocalized] FOREIGN KEY([CatalogItemId])
REFERENCES [dbo].[CatalogCategory] ([CatalogItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogCategoryLocalized] CHECK CONSTRAINT [FK_CatalogCategory_CatalogCategoryLocalized]
GO
ALTER TABLE [dbo].[CatalogItemLocalized]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogItem_CatalogItemLocalized] FOREIGN KEY([CatalogItemId])
REFERENCES [dbo].[CatalogItem] ([CatalogItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogItemLocalized] CHECK CONSTRAINT [FK_CatalogItem_CatalogItemLocalized]
GO
ALTER TABLE [dbo].[CatalogManagementPack]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogItem_CatalogManagementPack] FOREIGN KEY([CatalogItemId])
REFERENCES [dbo].[CatalogItem] ([CatalogItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogManagementPack] CHECK CONSTRAINT [FK_CatalogItem_CatalogManagementPack]
GO
ALTER TABLE [dbo].[CatalogManagementPack]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogVendor_CatalogManagementPack] FOREIGN KEY([VendorId])
REFERENCES [dbo].[CatalogVendor] ([VendorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogManagementPack] CHECK CONSTRAINT [FK_CatalogVendor_CatalogManagementPack]
GO
ALTER TABLE [dbo].[CatalogManagementPackCategory]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogCategory_CatalogManagementPackCategory] FOREIGN KEY([CategoryCatalogItemId])
REFERENCES [dbo].[CatalogCategory] ([CatalogItemId])
GO
ALTER TABLE [dbo].[CatalogManagementPackCategory] CHECK CONSTRAINT [FK_CatalogCategory_CatalogManagementPackCategory]
GO
ALTER TABLE [dbo].[CatalogManagementPackCategory]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogManagementPack_CatalogManagementPackCategory] FOREIGN KEY([ManagementPackCatalogItemId])
REFERENCES [dbo].[CatalogManagementPack] ([CatalogItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogManagementPackCategory] CHECK CONSTRAINT [FK_CatalogManagementPack_CatalogManagementPackCategory]
GO
ALTER TABLE [dbo].[CatalogManagementPackDependency]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogManagementPack_CatalogManagementPackDependency] FOREIGN KEY([ManagementPackCatalogItemId])
REFERENCES [dbo].[CatalogManagementPack] ([CatalogItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogManagementPackDependency] CHECK CONSTRAINT [FK_CatalogManagementPack_CatalogManagementPackDependency]
GO
ALTER TABLE [dbo].[CatalogManagementPackLocalized]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogManagementPack_CatalogManagementPackLocalized] FOREIGN KEY([CatalogItemId])
REFERENCES [dbo].[CatalogManagementPack] ([CatalogItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogManagementPackLocalized] CHECK CONSTRAINT [FK_CatalogManagementPack_CatalogManagementPackLocalized]
GO
ALTER TABLE [dbo].[CatalogProductCatalogItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogItem_CatalogProductCatalogItem] FOREIGN KEY([CatalogItemId])
REFERENCES [dbo].[CatalogItem] ([CatalogItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogProductCatalogItem] CHECK CONSTRAINT [FK_CatalogItem_CatalogProductCatalogItem]
GO
ALTER TABLE [dbo].[CatalogProductCatalogItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogProduct_CatalogProductCatalogItem] FOREIGN KEY([ProductId])
REFERENCES [dbo].[CatalogProduct] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogProductCatalogItem] CHECK CONSTRAINT [FK_CatalogProduct_CatalogProductCatalogItem]
GO
ALTER TABLE [dbo].[CatalogVendorLocalized]  WITH NOCHECK ADD  CONSTRAINT [FK_CatalogVendor_CatalogVendorLocalized] FOREIGN KEY([VendorId])
REFERENCES [dbo].[CatalogVendor] ([VendorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CatalogVendorLocalized] CHECK CONSTRAINT [FK_CatalogVendor_CatalogVendorLocalized]
GO
ALTER TABLE [dbo].[PackLocalizedData]  WITH NOCHECK ADD  CONSTRAINT [FK__PackLocal__LCID___0F975522] FOREIGN KEY([LCID_FK])
REFERENCES [dbo].[Language] ([LCID])
GO
ALTER TABLE [dbo].[PackLocalizedData] CHECK CONSTRAINT [FK__PackLocal__LCID___0F975522]
GO
ALTER TABLE [dbo].[PackProducts]  WITH NOCHECK ADD  CONSTRAINT [FK__PackProdu__Produ__117F9D94] FOREIGN KEY([ProductID_FK])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[PackProducts] CHECK CONSTRAINT [FK__PackProdu__Produ__117F9D94]
GO
ALTER TABLE [dbo].[SystemCenterProducts]  WITH NOCHECK ADD  CONSTRAINT [FK_SystemCenterProducts_Product] FOREIGN KEY([ProductID_FK])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[SystemCenterProducts] CHECK CONSTRAINT [FK_SystemCenterProducts_Product]
GO
ALTER TABLE [dbo].[SystemCenterProducts]  WITH NOCHECK ADD  CONSTRAINT [FK_SystemCenterProducts_SystemCenter] FOREIGN KEY([CenterID_FK])
REFERENCES [dbo].[SystemCenter] ([CenterID])
GO
ALTER TABLE [dbo].[SystemCenterProducts] CHECK CONSTRAINT [FK_SystemCenterProducts_SystemCenter]
GO
/****** Object:  StoredProcedure [dbo].[CatalogCategoryAssignedManagementPackGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogCategoryAssignedManagementPackGet]
(
   @CategoryId            int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryAssignedManagementPackGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/25/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Management Pack assigned to a category.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/16/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @CategoryId = ISNULL(@CategoryId,0)

  -- Main select
  SELECT
     c.CatalogItemId
    ,DefaultDisplayName
    ,VersionIndependentGuid
    ,Version
    ,SystemName
    ,PublicKey
    ,ReleaseDate
    ,VendorId
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd
    ,DefaultThirdPartyDownloadText
    ,DefaultThirdPartyDownloadLink
  FROM
    CatalogItem AS c        
        JOIN CatalogManagementPackCategory AS mpcat ON mpcat.CategoryCatalogItemId = @CategoryId AND mpcat.ManagementPackCatalogItemId = c.CatalogItemId
        JOIN CatalogManagementPack AS mp ON c.CatalogItemId = mp.CatalogItemId
  WHERE
    c.IsManagementPack = 'true'
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogCategoryExtendedInfoGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogCategoryExtendedInfoGet]
(
   @CatalogItemId             int = NULL
  ,@ThreeLetterLanguageCode   char(3) = 'ENU'
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/21/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Category Extended Information given a catalog item id and language code.

If id is 0, it returns all categories.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/21/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

  -- Main select
  SELECT
     c.CatalogItemId
    ,Description = ISNULL(LocalizedDescription, DefaultDescription)
  FROM
    CatalogItem AS c        
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
  WHERE
    c.IsCategory = 'true'
    AND ( @CatalogItemId = 0 OR @CatalogItemId = c.CatalogItemId )
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogCategoryGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogCategoryGet]
(
   @CatalogItemId             int = NULL
  ,@ThreeLetterLanguageCode   char(3) = 'ENU'
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Category Information given a catalog item id and language code.

If id is 0, it returns all categories.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/23/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

  -- Main select
  SELECT
     c.CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,GuideUriText = ISNULL(LocalizedGuideUriText, DefaultGuideUriText)
    ,GuideUriLink = ISNULL(LocalizedGuideUriLink, DefaultGuideUriLink)
    ,ParentCategoryId
    ,c.PublishedInd
    ,SortIndex
  FROM
    CatalogItem AS c        
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogCategory AS cat ON c.CatalogItemId = cat.CatalogItemId
        LEFT JOIN CatalogCategoryLocalized AS catloc on cat.CatalogItemId = catloc.CatalogItemId and catloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
  WHERE
    c.IsCategory = 'true'
    AND ( @CatalogItemId = 0 OR @CatalogItemId = c.CatalogItemId )
  ORDER BY SortIndex DESC, DisplayName


  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogCategoryLocGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogCategoryLocGet]
(
   @CategoryId                 int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryLocGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 12/09/2008

DESCRIPTION:
------------
This stored procedure is used to retrieve list of languages in which a category is localized.


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/09/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CategoryId = ISNULL(@CategoryId,0)

  -- Input Validation
  IF NOT EXISTS (SELECT CatalogItemId FROM CatalogCategory where CatalogItemId = @CategoryId)
  BEGIN
    RAISERROR('Cannot find the category with given category id', 16, 1)        
  END

  -- Main select
  SELECT
     loc.ThreeLetterLanguageCode 
  FROM
    CatalogCategoryLocalized AS loc
  WHERE 
  loc.CatalogItemId = @CategoryId
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogCategoryLocSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogCategoryLocSet]
(
   @CatalogItemId               int
  ,@DisplayName                 nvarchar(1024) = NULL
  ,@Description                 nvarchar(MAX)= NULL
  ,@GuideUriText                nvarchar(1024) = NULL
  ,@GuideUriLink                nvarchar(1024) = NULL
  ,@ThreeLetterLanguageCode     char(3)
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryLocSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Category given a catalog item id in specified language.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/23/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)

  IF @CatalogItemId = 0
    BEGIN
      RAISERROR('Cannot find the catalog category with the given catalog item id to update', 16, 1)        
    END
  ELSE 
    BEGIN
    
      BEGIN TRANSACTION;
 
    
      IF EXISTS (Select * from CatalogItemLocalized WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode)
        BEGIN
          --Update CatalogItemLocalized
          UPDATE CatalogItemLocalized
            SET
               LocalizedDisplayName = ISNULL(@DisplayName,LocalizedDisplayName)
              ,LocalizedDescription = ISNULL(@Description,LocalizedDescription)
            WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
          --Update CatalogCategoryLocalized
          UPDATE CatalogCategoryLocalized
            SET
               LocalizedGuideUriText = ISNULL(@GuideUriText,LocalizedGuideUriText)
              ,LocalizedGuideUriLink = ISNULL(@GuideUriText,LocalizedGuideUriLink)              
            WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        END
      ELSE
        BEGIN
          --Insert CatalogItem
          INSERT INTO CatalogItemLocalized (CatalogItemId,ThreeLetterLanguageCode,LocalizedDisplayName,LocalizedDescription)
            VALUES (@CatalogItemId,@ThreeLetterLanguageCode,@DisplayName,@Description)
          --Insert CatalogCategory
          INSERT INTO CatalogCategoryLocalized (CatalogItemId,ThreeLetterLanguageCode,LocalizedGuideUriText,LocalizedGuideUriLink)
            VALUES (@CatalogItemId,@ThreeLetterLanguageCode,@GuideUriText,@GuideUriLink);      
        END
        
      COMMIT TRANSACTION
    END
    
    
    
END TRY
  BEGIN CATCH
  
    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN

    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
    
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END

  SELECT @CatalogItemId

END
GO
/****** Object:  StoredProcedure [dbo].[CatalogCategorySet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogCategorySet]
(
     @CatalogItemId     int = NULL
    ,@DisplayName       nvarchar(1024) = NULL
    ,@Description       nvarchar(MAX) = NULL
    ,@ParentId          int = NULL
    ,@GuideUriText      nvarchar(1024) = NULL
    ,@GuideUriLink      nvarchar(MAX) = NULL
    ,@PublishedInd      bit = NULL
    ,@SortIndex         int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategorySet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Category given a catalog item id in ENU.

If id is 0, it inserts category.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/23/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)
  
  IF @CatalogItemId = 0
    BEGIN
    
      BEGIN TRANSACTION;
      
      SET @PublishedInd = ISNULL(@PublishedInd,'false')
      
      --Insert CatalogItem
      INSERT INTO CatalogItem (IsManagementPack,IsCategory,PublishedInd,DefaultDisplayName,DefaultDescription)
        VALUES ('false','true',@PublishedInd,@DisplayName,@Description)
      --Insert CatalogCategory
      
      SET @CatalogItemId = SCOPE_IDENTITY()
      
      INSERT INTO CatalogCategory (CatalogItemId,ParentCategoryId,DefaultGuideUriText,DefaultGuideUriLink,SortIndex)
        VALUES (@CatalogItemId,@ParentId,@GuideUriText,@GuideUriLink,@SortIndex);      
        
      COMMIT TRANSACTION;
    END
  ELSE
    BEGIN
      IF EXISTS (SELECT * FROM CatalogItem WHERE CatalogItemId = @CatalogItemId AND IsCategory = 'true')
        BEGIN
        
          BEGIN TRANSACTION;
          
          --Update CatalogItem
          UPDATE CatalogItem
            SET
               DefaultDisplayName = ISNULL(@DisplayName,DefaultDisplayName)
              ,DefaultDescription = ISNULL(@Description,DefaultDescription)
              ,PublishedInd = ISNULL(@PublishedInd,PublishedInd)              
            WHERE CatalogItemId = @CatalogItemId
          --Update CatalogCategory
          UPDATE CatalogCategory
            SET
               ParentCategoryId = ISNULL(@ParentId,ParentCategoryId)
              ,DefaultGuideUriText = ISNULL(@GuideUriText,DefaultGuideUriText)
              ,DefaultGuideUriLink = ISNULL(@GuideUriLink,DefaultGuideUriLink)
              ,SortIndex = ISNULL(@SortIndex,SortIndex)
            WHERE CatalogItemId = @CatalogItemId
            
          COMMIT TRANSACTION;
          
        END
      ELSE
        BEGIN
          RAISERROR('Cannot find the category with the given catalog item id to update', 16, 1)
        END
    END
    
    
    
END TRY
  BEGIN CATCH
  
    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN

  
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END

SELECT @CatalogItemId

END
GO
/****** Object:  StoredProcedure [dbo].[CatalogCategoryUnAssignedManagementPackGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogCategoryUnAssignedManagementPackGet]
(
   @CategoryId            int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryUnAssignedManagementPackGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/25/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Management Pack not assigned to a category.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/16/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @CategoryId = ISNULL(@CategoryId,0)

  -- Main select
  SELECT
     c.CatalogItemId
    ,DefaultDisplayName
    ,VersionIndependentGuid
    ,Version
    ,SystemName
    ,PublicKey
    ,ReleaseDate
    ,VendorId
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd
    ,DefaultThirdPartyDownloadText
    ,DefaultThirdPartyDownloadLink
  FROM
    CatalogItem AS c        
        JOIN CatalogManagementPack AS mp ON c.CatalogItemId = mp.CatalogItemId
  WHERE
    c.IsManagementPack = 'true'
    AND NOT EXISTS (SELECT ManagementPackCatalogItemId FROM CatalogManagementPackCategory WHERE CategoryCatalogItemId = @CategoryId and ManagementPackCatalogItemId = c.CatalogItemId)
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogItemAssociatedProductGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogItemAssociatedProductGet]
(
   @CatalogItemId                 int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogItemAssociatedProductGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 12/09/2008

DESCRIPTION:
------------
This stored procedure is used to retrieve list of products associated with a catalog item.


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/09/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)

  -- Input Validation
  IF NOT EXISTS (SELECT CatalogItemId FROM CatalogItem where CatalogItemId = @CatalogItemId)
  BEGIN
    RAISERROR('Cannot find the catalog item with given item id', 16, 1)        
  END

  -- Main select
  SELECT
     p.ProductId
    ,p.ProductName
    ,p.ProductVersion
  FROM
    CatalogProductCatalogItem AS c
  JOIN 
   CatalogProduct AS p ON (c.ProductId = p.ProductId)
  WHERE 
    c.CatalogItemId = @CatalogItemId
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogItemExtendedInfoGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[CatalogItemExtendedInfoGet]
(
     @CatalogItemXml              xml                 -- INPUT expects CatalogItem xml explained in description
    ,@ProductName                 nvarchar(1024)      -- INPUT expects Product name of the client
    ,@ProductVersion              nvarchar(25)        -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode     char(3) = 'ENU'     -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd  bit = NULL          -- INPUT expects indicator on whether to include unpublished items
)
AS
/****************************************************************************

PROCEDURE NAME: CatalogItemExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to retrieve CatalogItemExtendedInfo given the catalog item ids and a language code.

Sample Xml for CatalogItemXml:
<CatalogItems>
<CatalogItem ID="1"/>
<CatalogItem ID="2"/>
</CatalogItems>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/28/2008       maaakash      Created Stored Procedure.

****************************************************************************/
BEGIN
  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
    ,@XmlDocHandle    int
    ,@ExecResult      int

  SET @ErrorInd = 0

 BEGIN TRY

  -- Handle parameters
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

  -- Read the Xml
     EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @CatalogItemXml
     IF @ExecResult <> 0 RAISERROR(N'TODO: Fix this error message', 16, 1, @ExecResult)

  -- Create temp table 
  CREATE TABLE #CatalogItemIds (
    CatalogItemId int
  )

  -- Populate temp table 
  INSERT #CatalogItemIds(CatalogItemId)
    SELECT ID FROM OPENXML (@XmlDocHandle, '/CatalogItems/CatalogItem',1) WITH (ID int)

 
  -- Main select 
  SELECT 
	 c.CatalogItemId  -- CatalogItemId
	,Description = ISNULL(LocalizedDescription,DefaultDescription)
	,c.PublishedInd
  FROM 
	CatalogItem AS c
		LEFT JOIN CatalogItemLocalized AS loc ON loc.CatalogItemId = c.CatalogItemId and loc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
		JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
		JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
  WHERE 
	(@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')
	AND EXISTS (SELECT CatalogItemId from #CatalogItemIds AS ids WHERE ids.CatalogItemId = c.CatalogItemId)

END TRY
BEGIN CATCH
  SELECT 
     @ErrorNumber = ERROR_NUMBER()
    ,@ErrorSeverity = ERROR_SEVERITY()
    ,@ErrorState = ERROR_STATE()
    ,@ErrorLine = ERROR_LINE()
    ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
    ,@ErrorMessageText = ERROR_MESSAGE()

  SET @ErrorInd = 1
END CATCH


-- Cleanup

IF (@XmlDocHandle IS NOT NULL)
  EXEC sp_xml_removedocument @XmlDocHandle

IF (OBJECT_ID('#CatalogItemIds') IS NOT NULL)
  DROP TABLE #CatalogItemIds

-- report error if any
IF (@ErrorInd = 1)
BEGIN
  DECLARE @AdjustedErrorSeverity int
   SET @AdjustedErrorSeverity = CASE
                                 WHEN @ErrorSeverity > 18 THEN 18
                                 ELSE @ErrorSeverity
                               END
  
  RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
    ,@ErrorNumber
    ,@ErrorSeverity
    ,@ErrorState
    ,@ErrorProcedure
    ,@ErrorLine
    ,@ErrorMessageText
  )
END

	
END
GO
/****** Object:  StoredProcedure [dbo].[CatalogItemPublish]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogItemPublish]
(
     @CatalogItemXml    xml
    ,@PublishInd        bit = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogItemPublish

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/02/2008

DESCRIPTION:
------------
This store procedure is used to publish and unpublish catalog items.

Sample Xml for CatalogItemXml:
<CatalogItems>
<CatalogItem ID="1"/>
<CatalogItem ID="2"/>
</CatalogItems>


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/02/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
    ,@XmlDocHandle    int
    ,@ExecResult      int

  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  set @PublishInd = ISNULL(@PublishInd,1)
      
  -- Read the Xml
     EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @CatalogItemXml
     IF @ExecResult <> 0 RAISERROR(N'TODO: Fix this error message', 16, 1, @ExecResult)

  -- Create temp table 
  CREATE TABLE #CatalogItemIds (
    CatalogItemId int
  )

  -- Populate temp table 
  INSERT #CatalogItemIds(CatalogItemId)
    SELECT ID FROM OPENXML (@XmlDocHandle, '/CatalogItems/CatalogItem',1) WITH (ID int)

  
  --Update the CatalogItem table
  UPDATE CatalogItem
    SET PublishedInd = @PublishInd
    WHERE
      CatalogItemId IN (Select CatalogItemId FROM #CatalogItemIds) 

  --Select updated items and the operation
  SELECT c.CatalogItemId FROM CatalogItem AS c  WHERE EXISTS (SELECT CatalogItemId FROM #CatalogItemIds WHERE CatalogItemId = c.CatalogItemId)    
    
  SELECT @PublishInd
  
END TRY
  BEGIN CATCH
  
    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN

  
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH

  --Cleanup
  IF (@XmlDocHandle IS NOT NULL)
    EXEC sp_xml_removedocument @XmlDocHandle

  IF (OBJECT_ID('#CatalogItemIds') IS NOT NULL)
    DROP TABLE #CatalogItemIds

  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogItemUnAssociatedProductGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogItemUnAssociatedProductGet]
(
   @CatalogItemId                 int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogItemUnAssociatedProductGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 12/09/2008

DESCRIPTION:
------------
This stored procedure is used to retrieve list of products not associated with a catalog item.


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/09/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)

  -- Input Validation
  IF NOT EXISTS (SELECT CatalogItemId FROM CatalogItem where CatalogItemId = @CatalogItemId)
  BEGIN
    RAISERROR('Cannot find the catalog item with given item id', 16, 1)        
  END

  -- Main select
  SELECT
     p.ProductId
    ,p.ProductName
    ,p.ProductVersion
  FROM
   CatalogProduct AS p
  WHERE 
    NOT EXISTS (SELECT CatalogItemId FROM CatalogProductCatalogItem AS cp WHERE cp.CatalogItemId = @CatalogItemId AND cp.ProductId = p.ProductId);
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogManagementPackCategorySet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogManagementPackCategorySet]
(
   @ManagementPackCatalogItemId            int
  ,@CategoryCatalogItemId                  int
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackCategorySet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/02/2008

DESCRIPTION:
------------
This store procedure is used to add management packs to categories.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/02/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @ManagementPackCatalogItemId = ISNULL(@ManagementPackCatalogItemId,0)
  SET @CategoryCatalogItemId = ISNULL(@CategoryCatalogItemId,0)

  IF NOT EXISTS (SELECT * FROM CatalogManagementPackCategory WHERE ManagementPackCatalogItemId = @ManagementPackCatalogItemId AND CategoryCatalogItemId = @CategoryCatalogItemId)
    BEGIN
      INSERT INTO CatalogManagementPackCategory(ManagementPackCatalogItemId,CategoryCatalogItemId)
        VALUES (@ManagementPackCatalogItemId,@CategoryCatalogItemId)
    END
    
    
END TRY
  BEGIN CATCH

    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN
  
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END
  SELECT @ManagementPackCatalogItemId, @CategoryCatalogItemId
END
GO
/****** Object:  StoredProcedure [dbo].[CatalogManagementPackCategoryUnSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogManagementPackCategoryUnSet]
(
   @ManagementPackCatalogItemId            int
  ,@CategoryCatalogItemId                  int
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackCategoryUnSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/02/2008

DESCRIPTION:
------------
This store procedure is used to remove management packs to categories.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/17/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @ManagementPackCatalogItemId = ISNULL(@ManagementPackCatalogItemId,0)
  SET @CategoryCatalogItemId = ISNULL(@CategoryCatalogItemId,0)

  DELETE FROM CatalogManagementPackCategory WHERE ManagementPackCatalogItemId = @ManagementPackCatalogItemId AND CategoryCatalogItemId = @CategoryCatalogItemId   
    
END TRY
  BEGIN CATCH

    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN
  
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END
  SELECT @ManagementPackCatalogItemId, @CategoryCatalogItemId
END
GO
/****** Object:  StoredProcedure [dbo].[CatalogManagementPackDependencySet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogManagementPackDependencySet]
(
   @CatalogItemId            int
  ,@VersionIndependentGuid   uniqueidentifier
  ,@Version                  nvarchar(25)
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackDependencySet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/30/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Management Pack dependency.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/30/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)

  IF @CatalogItemId = 0 OR NOT EXISTS (SELECT * FROM CatalogManagementPack WHERE CatalogItemId = @CatalogItemId)
    BEGIN
      RAISERROR('Cannot find the management pack with the given catalog item id to set dependency', 16, 1)
    END
  ELSE IF EXISTS (SELECT * FROM CatalogManagementPackDependency WHERE ManagementPackCatalogItemId = @CatalogItemId AND DependentMpVersionIndependentGuid = @VersionIndependentGuid)
    BEGIN
      --Update CatalogManagementPackDependency
      UPDATE 
        CatalogManagementPackDependency
          SET 
            DependentMpVersion = @Version
          WHERE ManagementPackCatalogItemId = @CatalogItemId AND DependentMpVersionIndependentGuid = @VersionIndependentGuid
    END
  ELSE
    BEGIN     
      --Insert CatalogManagementPackDependency
      INSERT INTO CatalogManagementPackDependency (ManagementPackCatalogItemId,DependentMpVersionIndependentGuid,DependentMpVersion)
        VALUES (@CatalogItemId,@VersionIndependentGuid,@Version)
    END  
    
    
END TRY
  BEGIN CATCH

    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN
  
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END
  SELECT @CatalogItemId, @VersionIndependentGuid, @Version
END
GO
/****** Object:  StoredProcedure [dbo].[CatalogManagementPackExtendedInfoGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogManagementPackExtendedInfoGet]
(
   @CatalogItemId             int = NULL
  ,@ThreeLetterLanguageCode   char(3) = 'ENU'
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/23/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog MP Extended Information given a catalog item id and language code.

If id is 0, it returns all MPs.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/23/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

  -- Main select
  SELECT
     c.CatalogItemId
    ,MpDesc = ISNULL(LocalizedDescription, DefaultDescription)
    ,Knowledge = ISNULL(LocalizedKnowledge, DefaultKnowledge)
    ,Eula = ISNULL(LocalizedEula, DefaultEula)

  FROM
    CatalogItem AS c        
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS m ON c.CatalogItemId = m.CatalogItemId
        LEFT JOIN CatalogManagementPackLocalized AS mloc ON m.CatalogItemId = mloc.CatalogItemId  and mloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
  WHERE
    c.IsManagementPack = 'true'
    AND ( @CatalogItemId = 0 OR @CatalogItemId = c.CatalogItemId )
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogManagementPackGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogManagementPackGet]
(
   @CatalogItemId            int = NULL
  ,@ThreeLetterLanguageCode  char(3) = 'ENU'
	
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/25/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Management Pack Information given a catalog item id and language code.

If id is 0, it returns all Management Packs.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/25/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

  -- Main select
  SELECT
     c.CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,VersionIndependentGuid
    ,Version
    ,SystemName
    ,PublicKey
    ,ReleaseDate
    ,VendorId
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd
    ,ThirdPartyDownloadText = ISNULL(LocalizedThirdPartyDownloadText, DefaultThirdPartyDownloadText)
    ,ThirdPartyDownloadLink = ISNULL(LocalizedThirdPartyDownloadLink, DefaultThirdPartyDownloadLink)
  FROM
    CatalogItem AS c        
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS mp ON c.CatalogItemId = mp.CatalogItemId
		LEFT JOIN CatalogManagementPackLocalized AS mploc on mp.CatalogItemId = mploc.CatalogItemId and mploc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
  WHERE
    c.IsManagementPack = 'true'
    AND ( @CatalogItemId = 0 OR @CatalogItemId = c.CatalogItemId )
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogManagementPackLocGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogManagementPackLocGet]
(
   @ManagementPackId                 int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackLocGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 12/10/2008

DESCRIPTION:
------------
This stored procedure is used to retrieve list of languages in which a mp is localized.


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/10/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @ManagementPackId = ISNULL(@ManagementPackId,0)

  -- Input Validation
  IF NOT EXISTS (SELECT CatalogItemId FROM CatalogManagementPack where CatalogItemId = @ManagementPackId)
  BEGIN
    RAISERROR('Cannot find the mp with given mp id', 16, 1)        
  END

  -- Main select
  SELECT
     loc.ThreeLetterLanguageCode 
  FROM
    CatalogManagementPackLocalized AS loc
  WHERE 
  loc.CatalogItemId = @ManagementPackId
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogManagementPackLocSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogManagementPackLocSet]
(
   @CatalogItemId             int
  ,@DisplayName               nvarchar(1024) = NULL
  ,@Description               nvarchar(MAX) = NULL
  ,@LocalizedKnowledge        nvarchar(MAX) = NULL
  ,@LocalizedEula             nvarchar(MAX) = NULL
  ,@ThreeLetterLanguageCode   char(3)
  ,@LocalizedThirdPartyDownloadText   nvarchar(1024) = NULL
  ,@LocalizedThirdPartyDownloadLink   nvarchar(1024) = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackLocSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/25/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Management Pack given a catalog item id in specified language.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/25/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)

  IF @CatalogItemId = 0
    BEGIN
      RAISERROR('Cannot find the catalog management pack with the given catalog item id to update', 16, 1)        
    END
  ELSE 
    BEGIN
        
      BEGIN TRANSACTION;
    
      IF EXISTS (SELECT * FROM CatalogItemLocalized WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode)
        BEGIN
          --Update CatalogItemLocalized
          UPDATE CatalogItemLocalized
            SET
               LocalizedDisplayName = ISNULL(@DisplayName,LocalizedDisplayName)
              ,LocalizedDescription = ISNULL(@Description,LocalizedDescription)
            WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
          --Update CatalogManagementPackLocalized
          UPDATE CatalogManagementPackLocalized
            SET
               LocalizedKnowledge = ISNULL(@LocalizedKnowledge,LocalizedKnowledge)
              ,LocalizedEula = ISNULL(@LocalizedEula,LocalizedEula)
              ,LocalizedThirdPartyDownloadText = ISNULL(@LocalizedThirdPartyDownloadText,LocalizedThirdPartyDownloadText)
              ,LocalizedThirdPartyDownloadLink = ISNULL(@LocalizedThirdPartyDownloadLink,LocalizedThirdPartyDownloadLink)
            WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        END
      ELSE
        BEGIN
          --Insert CatalogItem
          INSERT INTO CatalogItemLocalized (CatalogItemId,ThreeLetterLanguageCode,LocalizedDisplayName,LocalizedDescription)
            VALUES (@CatalogItemId,@ThreeLetterLanguageCode,@DisplayName,@Description)
          --Insert CatalogManagementPackLocalized
          INSERT INTO CatalogManagementPackLocalized (CatalogItemId,ThreeLetterLanguageCode,LocalizedKnowledge,LocalizedEula,LocalizedThirdPartyDownloadText,LocalizedThirdPartyDownloadLink)
            VALUES (@CatalogItemId,@ThreeLetterLanguageCode,@LocalizedKnowledge,@LocalizedEula,@LocalizedThirdPartyDownloadText,@LocalizedThirdPartyDownloadLink)
        END
      COMMIT TRANSACTION;
    END
    
    
    
END TRY
  BEGIN CATCH

    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN

    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1

  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END

  SELECT @CatalogItemId

END
GO
/****** Object:  StoredProcedure [dbo].[CatalogManagementPackSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogManagementPackSet]
(
   @CatalogItemId            int = NULL
  ,@DisplayName              nvarchar(1024) = NULL
  ,@Description              nvarchar(MAX) = NULL
  ,@VersionIndependentGuid   uniqueidentifier = NULL
  ,@Version                  nvarchar(25) = NULL
  ,@SystemName               nvarchar(256) = NULL
  ,@PublicKey                varchar(32) = NULL
  ,@ReleaseDate              datetime = NULL
  ,@VendorId                 int = NULL
  ,@DownloadUri              nvarchar(1024) = NULL
  ,@DefaultKnowledge         nvarchar(MAX) = NULL
  ,@EulaInd                  bit = NULL
  ,@DefaultEula              nvarchar(MAX) = NULL
  ,@SecurityInd              bit = NULL
  ,@PublishedInd             bit = NULL
  ,@DefaultThirdPartyDownloadText   nvarchar(1024) = NULL
  ,@DefaultThirdPartyDownloadLink   nvarchar(1024) = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/25/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Management Pack given a catalog item id in ENU.

If id is 0, it inserts management pack.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/25/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)

  IF @CatalogItemId = 0
    BEGIN
    
      BEGIN TRANSACTION;
      
      SET @PublishedInd = ISNULL(@PublishedInd,'false')
    
      --Insert CatalogItem
      INSERT INTO CatalogItem (IsManagementPack,IsCategory,PublishedInd,DefaultDisplayName,DefaultDescription)
        VALUES ('true','false',@PublishedInd,@DisplayName,@Description)
        
      SET @CatalogItemId = SCOPE_IDENTITY()
        
      --Insert CatalogManagementPack
      INSERT INTO CatalogManagementPack (CatalogItemId,VersionIndependentGuid,Version,SystemName,PublicKey,ReleaseDate,VendorId,DownloadUri,DefaultKnowledge,EulaInd,DefaultEula,SecurityInd,DefaultThirdPartyDownloadText,DefaultThirdPartyDownloadLink)
        VALUES (@CatalogItemId,@VersionIndependentGuid,@Version,@SystemName,@PublicKey,@ReleaseDate,@VendorId,@DownloadUri,@DefaultKnowledge,@EulaInd,@DefaultEula,@SecurityInd,@DefaultThirdPartyDownloadText,@DefaultThirdPartyDownloadLink);
        
      COMMIT TRANSACTION;
      
    END
  ELSE
    BEGIN
      IF EXISTS (SELECT * FROM CatalogItem WHERE CatalogItemId = @CatalogItemId AND IsManagementPack = 'true')
        BEGIN
        
          BEGIN TRANSACTION;
          
          --Update CatalogItem
          UPDATE CatalogItem
            SET
               DefaultDisplayName = ISNULL(@DisplayName,DefaultDisplayName)
              ,DefaultDescription = ISNULL(@Description,DefaultDescription)
              ,PublishedInd = ISNULL(@PublishedInd,PublishedInd)
            WHERE CatalogItemId = @CatalogItemId
          --Update CatalogManagementPack
          UPDATE CatalogManagementPack
            SET
               VersionIndependentGuid = ISNULL(@VersionIndependentGuid,VersionIndependentGuid)
              ,Version = ISNULL(@Version,Version)
              ,SystemName = ISNULL(@SystemName,SystemName)
              ,PublicKey = ISNULL(@PublicKey,PublicKey)
              ,ReleaseDate = ISNULL(@ReleaseDate,ReleaseDate)
              ,VendorId = ISNULL(@VendorId,VendorId)
              ,DownloadUri = ISNULL(@DownloadUri,DownloadUri)
              ,DefaultKnowledge = ISNULL(@DefaultKnowledge,DefaultKnowledge)
              ,EulaInd = ISNULL(@EulaInd,EulaInd)
              ,DefaultEula = ISNULL(@DefaultEula,DefaultEula)
              ,SecurityInd = ISNULL(@SecurityInd,SecurityInd)
              ,DefaultThirdPartyDownloadText = ISNULL(@DefaultThirdPartyDownloadText,DefaultThirdPartyDownloadText)
              ,DefaultThirdPartyDownloadLink = ISNULL(@DefaultThirdPartyDownloadLink,DefaultThirdPartyDownloadLink)
            WHERE CatalogItemId = @CatalogItemId
          
          COMMIT TRANSACTION;
          
        END
      ELSE
        BEGIN
          RAISERROR('Cannot find the management pack with the given catalog item id to update', 16, 1)
        END
    END
    
    
    
END TRY
  BEGIN CATCH

    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN
  
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END

SELECT @CatalogItemId,@VersionIndependentGuid,@Version

END
GO
/****** Object:  StoredProcedure [dbo].[CatalogProductCatalogItemGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogProductCatalogItemGet]
(
   @CatalogItemId             int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogProductCatalogItemGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/09/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Products that a Catalog Item belongs to.

If id is 0, it returns all catalog item mappings.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/09/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)

  -- Main select
  SELECT
     ProductId
    ,CatalogItemId
  FROM
    CatalogProductCatalogItem AS c        
  WHERE
    ( @CatalogItemId = 0 OR @CatalogItemId = c.CatalogItemId )
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogProductCatalogItemSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogProductCatalogItemSet]
(
   @CatalogItemId            int
  ,@ProductId                int
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogProductCatalogItemSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/02/2008

DESCRIPTION:
------------
This store procedure is used to relate catalog items to product.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/02/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)
  SET @ProductId = ISNULL(@ProductId,0)

  IF NOT EXISTS (SELECT * FROM CatalogProductCatalogItem WHERE CatalogItemId = @CatalogItemId AND ProductId = @ProductId)
    BEGIN
      INSERT INTO CatalogProductCatalogItem(CatalogItemId,ProductId)
        VALUES (@CatalogItemId,@ProductId)
    END
    
    
END TRY
  BEGIN CATCH

    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN
  
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END
  SELECT @ProductId, @CatalogItemId
END
GO
/****** Object:  StoredProcedure [dbo].[CatalogProductCatalogItemUnSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogProductCatalogItemUnSet]
(
   @CatalogItemId            int
  ,@ProductId                int
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogProductCatalogItemUnSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/02/2008

DESCRIPTION:
------------
This store procedure is used to relate catalog items to product.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/02/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)
  SET @ProductId = ISNULL(@ProductId,0)

  DELETE FROM CatalogProductCatalogItem WHERE CatalogItemId = @CatalogItemId AND ProductId = @ProductId
    
END TRY
  BEGIN CATCH

    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN
  
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END
  SELECT @ProductId, @CatalogItemId
END
GO
/****** Object:  StoredProcedure [dbo].[CatalogProductGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[CatalogProductGet]
(
  @ProductId    int = NULL	
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogProductGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/19/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Product Information given a product id.

If id is 0, it returns all catalog products.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/19/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  set @ProductId = ISNULL(@ProductId,0)

  -- Main select
  SELECT
     p.ProductId
    ,p.ProductName
    ,p.ProductVersion
  FROM
    CatalogProduct AS p
  WHERE 
  ( @ProductId = 0 OR @ProductId = p.ProductId )
  ORDER BY p.ProductName
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogProductSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[CatalogProductSet]
(
   @ProductId         int = NULL
  ,@ProductName       nvarchar(1024)
  ,@ProductVersion    nvarchar(25)	
)
AS


/****************************************************************************

PROCEDURE NAME: CatalogProductSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/19/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Product Information given a product id.

If id is 0, it inserts catalog products.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/19/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @ProductId = ISNULL(@ProductId,0)

  IF @ProductId = 0
    BEGIN
          INSERT INTO CatalogProduct (ProductName,ProductVersion)
      VALUES (@ProductName,@ProductVersion)
      
      SET @ProductId = SCOPE_IDENTITY()
      
    END
  ELSE
    BEGIN
      IF EXISTS (SELECT * FROM CatalogProduct WHERE ProductId = @ProductId)
        BEGIN
          UPDATE CatalogProduct
            SET
               ProductName = ISNULL(@ProductName,ProductName)
              ,ProductVersion = ISNULL(@ProductVersion,ProductVersion)
            WHERE ProductId = @ProductId
        END
      ELSE
        BEGIN
          RAISERROR('Cannot find the product with the given product id to update', 16, 1)
        END
    END
    
    
    
END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END

SELECT @ProductId

END
GO
/****** Object:  StoredProcedure [dbo].[CatalogVendorGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogVendorGet]
(
   @VendorId                 int = NULL
  ,@ThreeLetterLanguageCode  char(3) = 'ENU'
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogVendorGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Vendor Information given a vendor id and language code.

If id is 0, it returns all vendors.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/23/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @VendorId = ISNULL(@VendorId,0)
  SET @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

  -- Main select
  SELECT
     v.VendorId
    ,VendorName = ISNULL(LocalizedVendorName, DefaultVendorName)
    ,VendorLink = ISNULL(LocalizedVendorLink, DefaultVendorLink)
  FROM
    CatalogVendor AS v
    LEFT JOIN CatalogVendorLocalized AS loc ON (v.VendorId = loc.VendorId and loc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode)
  WHERE 
  ( @VendorId = 0 OR @VendorId = v.VendorId )
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogVendorLocGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogVendorLocGet]
(
   @VendorId                 int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogVendorLocGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 12/09/2008

DESCRIPTION:
------------
This stored procedure is used to retrieve list of languages in which a vendor is localized.


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/09/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @VendorId = ISNULL(@VendorId,0)

  -- Input Validation
  IF NOT EXISTS (SELECT VendorId FROM CatalogVendor where VendorId = @VendorId)
  BEGIN
    RAISERROR('Cannot find the vendor with given vendor id', 16, 1)        
  END

  -- Main select
  SELECT
     loc.ThreeLetterLanguageCode 
  FROM
    CatalogVendorLocalized AS loc
  WHERE 
  loc.VendorId = @VendorId
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CatalogVendorLocSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogVendorLocSet]
(
   @VendorId                 int
  ,@VendorName               nvarchar(1024) = NULL
  ,@VendorLink               nvarchar(1024) = NULL
  ,@ThreeLetterLanguageCode  char(3)
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogVendorSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Vendor Information in the chosen language.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/23/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @VendorId = ISNULL(@VendorId,0)

  IF @VendorId = 0 OR NOT EXISTS (Select * from CatalogVendor WHERE VendorId = @VendorId)
    BEGIN
      RAISERROR('Cannot find the vendor with the given vendor id to update', 16, 1)    
    END
  ELSE
    BEGIN
      IF EXISTS (Select * from CatalogVendorLocalized WHERE VendorId = @VendorId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode)
        BEGIN
          UPDATE CatalogVendorLocalized
            SET
               LocalizedVendorName = ISNULL(@VendorName,LocalizedVendorName)
              ,LocalizedVendorLink = ISNULL(@VendorLink,LocalizedVendorLink)
            WHERE VendorId = @VendorId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        END
      ELSE
        BEGIN
          INSERT INTO CatalogVendorLocalized (VendorId, LocalizedVendorName, LocalizedVendorLink, ThreeLetterLanguageCode)
            VALUES (@VendorId, @VendorName, @VendorLink, @ThreeLetterLanguageCode)
        END
    END
    
    
    
END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END

  SELECT @VendorId

END
GO
/****** Object:  StoredProcedure [dbo].[CatalogVendorSet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CatalogVendorSet]
(
   @VendorId        int = NULL
  ,@VendorName      nvarchar(1024)
  ,@VendorLink      nvarchar(1024)
)
AS


/****************************************************************************

PROCEDURE NAME: CatalogVendorSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Vendor Information in 'ENU'.

If id is 0, it inserts new vendor.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/23/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  
  SET @VendorId = ISNULL(@VendorId,0)

  IF @VendorId = 0
    BEGIN
          INSERT INTO CatalogVendor (DefaultVendorName,DefaultVendorLink)
      VALUES (@VendorName,@VendorLink)
      
      SET @VendorId = SCOPE_IDENTITY()
      
    END
  ELSE
    BEGIN
      IF EXISTS (SELECT * FROM CatalogVendor WHERE VendorId = @VendorId)
        BEGIN
          UPDATE CatalogVendor
            SET
               DefaultVendorName = ISNULL(@VendorName,DefaultVendorName)
              ,DefaultVendorLink = ISNULL(@VendorLink,DefaultVendorLink)
            WHERE VendorId = @VendorId
        END
      ELSE
        BEGIN
          RAISERROR('Cannot find the vendor with the given vendor id to update', 16, 1)
        END
    END
    
    
    
END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END

  SELECT @VendorId
END
GO
/****** Object:  StoredProcedure [dbo].[CategoryGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[CategoryGet]
(
     @ThreeLetterLanguageCode       char(3) = 'ENU'         -- INPUT expects three letter language code for the locale of returned info
)
AS

/****************************************************************************

PROCEDURE NAME: CategoryGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/02/2008

DESCRIPTION:
------------
This store procedure is used to retrieve category information given the category information in a temp table #CategoryIds

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/02/2008       maaakash      Created Stored Procedure.
1.1         11/19/2008       maaakash      Sort the category result by display name.
****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY

  -- Parameter handling
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')


  -- Output category information

  SELECT
     c.CatalogItemId --CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,GuideUriText = ISNULL(LocalizedGuideUriText, DefaultGuideUriText)
    ,GuideUriLink = ISNULL(LocalizedGuideUriLink, DefaultGuideUriLink)
    ,ParentCategoryId
    ,c.PublishedInd
    ,SortIndex
  FROM
    CatalogItem AS c
        JOIN #CategoryIds AS ids on ids.CategoryId = c.CatalogItemId    
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogCategory AS cat ON c.CatalogItemId = cat.CatalogItemId
        LEFT JOIN CatalogCategoryLocalized AS catloc on cat.CatalogItemId = catloc.CatalogItemId and catloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
  ORDER BY SortIndex DESC, DisplayName


  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CategoryParentIdsGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CategoryParentIdsGet]
(
     @Level                         int = 0                 -- INPUT the number of levels of parents to fetch
    ,@ProductName                   nvarchar(1024)          -- INPUT expects Product name of the client
    ,@ProductVersion                nvarchar(25)                -- INPUT expects Product version of the client
    ,@IncludeUnpublishedItemsInd    bit = NULL              -- INPUT expects indicator on whether to include unpublished items
)
AS

/****************************************************************************

PROCEDURE NAME: CategoryParentIdsGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/02/2008

DESCRIPTION:
------------
This store procedure is used to recursively retrieve the parent ids upto a given level.
The category id information is stored in a temp table #CategoryIds
Which needs to contain the category ids whose parents need to be found when this SP is first called.

The #CategoryIds table should have the following schema:
  CREATE TABLE #CategoryIds
  (
    CategoryId int
    ,Level     int
  )


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/02/2008       maaakash      Created Stored Procedure.
1.1         11/19/2008       maaakash      Fixed an issue making the SP return only distinct parent category id.
****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY


  -- Parameter Handling
  
  set @Level = ISNULL(@Level,0)
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')  

  
  DECLARE
    @LevelCounter int
    
  set @LevelCounter = 0
  
  IF @Level = 0
  BEGIN
    set @Level = 1024 -- Assuming 1024 is the max depth
  END
 

  --Recurse till no more parent categories exist
  WHILE EXISTS(Select * from #CategoryIds where Level = @LevelCounter) AND @Level >@LevelCounter
  BEGIN    
   
    INSERT #CategoryIds(CategoryId,Level)
      SELECT
        DISTINCT(ParentCategoryId)
        ,@LevelCounter + 1
      FROM
        CatalogCategory AS c
          JOIN #CategoryIds AS t on c.CatalogItemId = t.CategoryId AND Level = @LevelCounter
          JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
          JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
          JOIN CatalogItem AS ci ON c.CatalogItemId = ci.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR ci.PublishedInd = 'true')
      WHERE ParentCategoryId NOT IN (SELECT CategoryId from #CategoryIds)

    set @LevelCounter = @LevelCounter + 1
        
  END



  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[CategorySubCategoryIdsGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CategorySubCategoryIdsGet]
(
     @Level                         int = 0                 -- INPUT the number of levels of sub categories to fetch
    ,@ProductName                   nvarchar(1024)          -- INPUT expects Product name of the client
    ,@ProductVersion                nvarchar(25)                -- INPUT expects Product version of the client
    ,@IncludeUnpublishedItemsInd    bit = NULL              -- INPUT expects indicator on whether to include unpublished items
)
AS

/****************************************************************************

PROCEDURE NAME: CategorySubCategoryIdsGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/02/2008

DESCRIPTION:
------------
This store procedure is used to recursively retrieve the sub category ids upto a given level.
The category id information is stored in a temp table #CategoryIds
Which needs to contain the category ids whose parents need to be found when this SP is first called.

The #CategoryIds table should have the following schema:
  CREATE TABLE #CategoryIds
  (
    CategoryId int
    ,Level     int
  )


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/02/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
  SET @ErrorInd = 0

  BEGIN TRY


  -- Parameter Handling
  
  set @Level = ISNULL(@Level,0)
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')  

  
  DECLARE
    @LevelCounter int
    
  set @LevelCounter = 0
  
  IF @Level = 0
  BEGIN
    set @Level = 1024 -- Assuming 1024 is the max depth
  END
 

  --Recurse till no more sub categories exist
  WHILE EXISTS(Select * from #CategoryIds where Level = @LevelCounter) AND @Level >@LevelCounter
  BEGIN    
   
    INSERT #CategoryIds(CategoryId,Level)
      SELECT
         c.CatalogItemId
        ,@LevelCounter + 1
      FROM
        CatalogCategory AS c
          JOIN #CategoryIds AS t on c.ParentCategoryId = t.CategoryId AND t.Level = @LevelCounter
          JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
          JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
          JOIN CatalogItem AS ci ON c.CatalogItemId = ci.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR ci.PublishedInd = 'true')
      WHERE c.CatalogItemId NOT IN (SELECT CategoryId from #CategoryIds)

    set @LevelCounter = @LevelCounter + 1
        
  END



  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomerFeedbackInformation]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************************************
PROCEDURE NAME:    DeleteCustomerFeedbackInformation
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Cleans PackFeedback feedback table by deleting records that are two weeks old?

RETURN VALUES:
None

PARAMETERS:
None

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/

Create procedure [dbo].[DeleteCustomerFeedbackInformation]
as
	delete from packfeedback where datediff(d,Createddatetime,getdate()) >28
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerFeedbackInformation]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****************************************************************************
PROCEDURE NAME:    GetCustomerFeedbackInformation
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Returns data from PackFeedback feedback table that is newer than LastUpdatedDateTime

RETURN VALUES:
None

PARAMETERS:
@LastupdateDateTime datetime

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/

CREATE procedure [dbo].[GetCustomerFeedbackInformation]
@LastupdateDateTime varchar(50)
as
	select FeedbackID,SRVID,PackID_Feedback,ProductID_Feedback,TimeOfUsage,MeetNeedsGrade,SatisfactionGrade,Reason,Improvements,CreatedDateTime,HexPUID 
	from PackFeedback where CreatedDateTime>=@LastUpdateDateTime
GO
/****** Object:  StoredProcedure [dbo].[GetDataForCatalogDropDowns]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****************************************************************************
PROCEDURE NAME:    GetDataForCatalogDropDowns
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-2

DESCRIPTION:
Returns data needed to build drop down controls on Catalog page

RETURN DATA:
Three recordsets:
List of all active products,
List of all active packs that are used in all pack versions accoding to IsPreview flag
PackName and ApplicationName are localized if local versions exist
List of all active products that packs above are related

PARAMETERS:
@CenterID smallint,-- can be 0 or null
@LCID int, -- can be 0 or null
@IsPreview bit - can't be null

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
1.1			10/31/07				 removed CenterID param and code connected with its usage
****************************************************************************/

CREATE procedure [dbo].[GetDataForCatalogDropDowns]
@LCID int,
@IsPreview bit
as

declare @ENGLISH_LCID int
set @ENGLISH_LCID=1033

if ((@lcid is null) or (@LCID=0))
	set @lcid=@ENGLISH_LCID


if @IsPreview is null
	set @IsPreview=1

select ProductID, ProductName, SortOrder from Product
where IsProductActive=1
Order by SortOrder

if (@lcid=@ENGLISH_LCID)
begin
	select PackID,PackVersion,rtrim(PackName) as PackName,rtrim(ApplicationName) as ApplicationName,rtrim(VendorName) as VendorName from Pack where IsPackActive=1 and IsPreview=@IsPreview
	and exists(select 1 from packproducts join product on productid_fk=productid where packidprod=packid and ispreviewprod=@IsPreview and IsProductActive=1)
	order by PackName,ApplicationName,VendorName
end
else
begin
	select PackID,
	PackVersion=case when PackNameloc is null then PackVersion else rtrim(PackVersionLoc) end,
	PackName=case when PackNameloc is null then rtrim(PackName) else rtrim(PackNameLoc) end,ApplicationName =case when ApplicationNameLoc is null then rtrim(ApplicationName) else rtrim(applicationNameLoc) end,rtrim(VendorName) as VendorName
	from Pack  
	left join PackLocalizedData on packid=packidloc and IsPreview=IsPreviewLoc and lcid_fk=@lcid
	where isPackActive=1 and IsPreview=@IsPreview
	and exists(select 1 from packproducts join product on productid_fk=productid where packidprod=packid and ispreviewprod=@IsPreview and IsProductActive=1)
	order by PackName,ApplicationName,VendorName
end

select PackIDProd,ProductID_FK from PackProducts 
join product on productid_fk=productid
join pack on packid=packidprod and ispreviewprod=ispreview 
where IsProductActive=1 and IsPreviewProd=@IsPreview and IsPackActive=1
GO
/****** Object:  StoredProcedure [dbo].[GetDataForFeedbackDropDowns]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************************************
PROCEDURE NAME:    GetDataForFeedbackDropDowns
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-2

DESCRIPTION:
Returns data needed to build drop down controls on Catalog page

RETURN DATA:
Three recordsets:
List of all  products,
List of all  packs that are used in all pack versions 
PackName and ApplicationName are localized if local versions exist
List of all  products that packs above are related

PARAMETERS:
@LCID int, -- can be 0 or null


HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE

****************************************************************************/
CREATE procedure [dbo].[GetDataForFeedbackDropDowns]
@LCID int
as

declare @ENGLISH_LCID int
set @ENGLISH_LCID=1033

if ((@lcid is null) or (@LCID=0))
	set @lcid=@ENGLISH_LCID


declare @IS_PREVIEW bit
set @IS_PREVIEW=0

select ProductID, ProductName, SortOrder from product
Order by SortOrder

if (@lcid=@ENGLISH_LCID)
begin
	select PackID,PackVersion,rtrim(PackName) as PackName,rtrim(ApplicationName) as ApplicationName from Pack where IsPreview=@IS_PREVIEW
	order by PackName,ApplicationName,VendorName
end
else
begin
	select PackID,
	PackVersion=case when PackNameloc is null then PackVersion else PackVersionLoc end,
	PackName=case when PackNameloc is null then rtrim(PackName) else rtrim(PackNameLoc) end,ApplicationName =case when ApplicationNameLoc is null then rtrim(ApplicationName) else rtrim(applicationNameLoc) end
	from Pack  
	left join PackLocalizedData on packid=packidloc and IsPreview=IsPreviewLoc and lcid_fk=@lcid
	where  IsPreview=@IS_PREVIEW
	order by PackName,ApplicationName,VendorName
end

select PackIDProd,ProductID_FK from PackProducts 
join product on productid_fk=productid
join pack on packid=packidprod and ispreviewprod=ispreview 
where  IsPreviewProd=@IS_PREVIEW
GO
/****** Object:  StoredProcedure [dbo].[GetSearchResults]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****************************************************************************
PROCEDURE NAME:    GetSearchResults
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-2

DESCRIPTION:
Returns search results for catalog page

DEPENDENCIES:
functions
dbo.getchartablefromstring
dbo.CleanParam
dbo.ParseStringIntoToken
dbo.FormatDateShort
dbo.GetPackLangList

RETURN VALUES:
NONE
PARAMETERS:
@IsPreview bit,
@LCID int,
@ProductID smallint,
@ApplicationName nvarchar(100),
@PackID int,
@VendorName nvarchar(100),
@KeyWords nvarchar(300) in form <word/token> <word/token>... where token is "<word> <word>..."
@IncludeActivePacks bit,
@IncludeInactivePacks bit,
@IncludePublishedPacks bit,
@IncludeUnpublishedPacks bit,
@SortOrder varchar(100)-- fields for sorting ApplicationName, VendorName,LastUpdatedDateTime,PackName,IsPackActive

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE

****************************************************************************/

CREATE procedure [dbo].[GetSearchResults]
@IsPreview bit,
@LCID int,
@ProductID smallint,
@ApplicationName nvarchar(100),
@PackID int,
@VendorName nvarchar(100),
@KeyWords nvarchar(200),
@SortOrder varchar(100)-- fields for sorting ApplicationName, VendorName,LastUpdatedDateTime,PackName,IsPackActive
WITH EXECUTE AS  OWNER
as

if @IsPreview is null
	set @IsPreview=1

DECLARE @ENGLISH_LCID int
set @ENGLISH_LCID=1033
if ((@lcid is null) or (@lcid=0))
	set @lcid=@ENGLISH_LCID
declare @SORT_FIELDS nvarchar(500),@SORT_ASC nvarchar(20)
set @SORT_FIELDS='-ApplicationName-VendorName-LastUpdatedDateTime-PackName-IsPackActive-'
set @SORT_ASC='-ASC-DESC-'
declare @SortField nvarchar(30),@SortAscDesc nvarchar(30),@Pos int
if (@SortOrder is null) 
	set @sortorder=''
set @SortOrder=rtrim(ltrim(@SortOrder))
-- Validate SortOrder param if it's not empty
if (len(@SortOrder)>0)
begin
	set @Pos = charindex(' ',@SortOrder)

	if (@Pos=0) 
	begin
		set @SortField=@SortOrder
		set @SortAscDesc=''
	end
	else
	begin
		set @SortField=left(@SortOrder,@Pos-1)
		set @SortAscDesc=ltrim(right(@SortOrder,len(@SortOrder) +1 - @Pos))
	end
    set @SortField='-' + @SortField + '-'
	if (len(@SortAscDesc)>0)
		set @SortAscDesc='-' + @SortAscDesc+ '-'

	if ((charindex(@SortField,@SORT_FIELDS) =0 ) OR ((len(@SortAscDesc)>0) and (charindex(@SortAscDesc,@SORT_ASC)=0)))
	begin
		set @SortOrder=''
	end
end

DECLARE @ParmDefinitionBoth nvarchar(500),@ParmDefinitionApp nvarchar(200), @ParmDefinitionVnd nvarchar(200)

SET @ParmDefinitionBoth = N'@ApplicationNamePar nvarchar(100),@VendorNamePar nvarchar(100)';
SET @ParmDefinitionApp = N'@ApplicationNamePar nvarchar(100)';
SET @ParmDefinitionVnd = N'@VendorNamePar nvarchar(100)';

declare @UNPUBLISH_DATE nvarchar(8)
set @UNPUBLISH_DATE='1/1/2100'

declare @KeyPackID int
declare @sql nvarchar(max), @sqlwhere nvarchar(max),@sqlorder nvarchar(200),@sqlwherebykeys nvarchar(4000)
set @sqlwhere=''
set @sqlorder=''


set @sql=N'select PackVersion=case when PackNameLoc is null then p.PackVersion else PackVersionLoc end,'
set @sql =@sql + N'ApplicationName=case when ApplicationNameLoc is null then p.ApplicationName else ApplicationNameLoc end,p.VendorName,p.VendorURL,'
set @sql =@sql + N'description=case when DescriptionLoc is null then p.Description else DescriptionLoc end,'
set @sql=@sql + N'dbo.FormatDateShort(case when LastUpdatedDateTimeLoc is null then p.LastUpdatedDateTime else p.LastUpdatedDateTime end) as FormatedLastUpdatedDateTime,'
set @sql=@sql + N'p.PackID,PackName=case when PackNameLoc is null then p.PackName else PackNameLoc end,'
set @sql =@sql + N'DownloadURL=case when DownloadURLLoc is null then p.DownloadURL else DownloadURLLoc end,'
set @sql=@sql + N'dbo.GetPackLangList(p.PackID,' + convert(char(1),@IsPreview) + ') as LangList '
--set @sql=@sql + '''French, German, Spanish'' as LangList '
set @sql=@sql + N'from Pack p '
set @sql=@Sql + N'left join packlocalizeddata on packid=packidloc and ispreview=isPreviewLoc  and lcid_fk=' + convert(varchar(5),@lcid) + '  '
set @sql=@Sql + ' where IsPackActive =1 and IsPreview =' + convert(char(1),@IsPreview) 
set @sql=@sql + ' and exists(select 1 from packproducts join product on productid_fk=productid where packidprod=p.packid and ispreviewprod=' + convert(char(1),@IsPreview) + ' and IsProductActive=1) '


set @keywords=rtrim(ltrim(@keywords))
if len(@Keywords)>0
begin
	select @KeyPackID = CASE WHEN @keywords not LIKE '%[^0-9]%' and len(@keywords)<9
	THEN CONVERT(int, @keywords)
	ELSE NULL
	END
	if @KeyPackID is null
	begin
		declare @i smallint,@Word nvarchar(200),@WordCnt smallint
		set @KeyWords=dbo.CleanParam(@KeyWords)
		declare @KeyWordTable table(recID smallint,word nvarchar(200))
		insert into @keyWordTable (recID,word)
		select cnt,token from dbo.getchartablefromstring(dbo.ParseStringIntoTokens(@KeyWords),'^') 

		select @WordCnt=count(*) from @KeyWordTable

		set @I=1
		set @sqlwherebykeys='('

		while @I<=@WordCnt
		begin
			select @Word=Word from @KeyWordTable where recID=@I
			if @sqlwherebykeys <>'('
				set @sqlwherebykeys=@sqlwherebykeys + ' and '

			set @sqlwherebykeys=@sqlwherebykeys + '((ApplicationName like ''%' + @word + '%'') or (PackName like ''%' + @word + '%'') or (Description like ''%' + @word + '%'')'
			set @sqlwherebykeys=@sqlwherebykeys + 'or (ApplicationNameLoc like ''%' + @word + '%'') or (PackNameLoc like ''%' + @word + '%'') or (DescriptionLoc like ''%' + @word + '%'')'
			set @sqlwherebykeys=@sqlwherebykeys + ')'
			set @I=@i+1
		end
		set @sqlwherebykeys=@sqlwherebykeys + ')'
	end
end

if @KeyPackID is null
begin
	if @PackID>0 
	begin
		
		set @sqlwhere=@sqlwhere + ' and p.PackID=' + convert(varchar(5),@PackID) + ' '
	end

	if @ProductID>0
	begin
		set @sqlwhere= @sqlWhere + ' and exists(select 1 from PackProducts join product on productid=productID_FK where isProductActive=1 and isPreviewProd= ' + convert(char(1),@IsPreview) + ' and packidprod=packid and productID_FK= ' + convert(varchar(4),@ProductID) + ') '
	end

	if len(@ApplicationName)>0
	begin
		
		set @sqlwhere=@sqlwhere + ' and ((ApplicationName=@ApplicationNamePar) '
		set @sqlwhere=@sqlwhere + ' or (ApplicationNameLoc=@ApplicationNamePar)'
		set @sqlwhere=@sqlwhere + ') '
	end

	if len(@VendorName)>0
	begin
		set @sqlwhere=@sqlwhere + ' and VendorName=@VendorNamePar '
	end
	
	
end
else
begin
	set @sqlwhere=' and p.PackID=' + convert(varchar(5),@KeyPackID) + ' '

end

if len(rtrim(@SortOrder))>0
	set @sqlorder=' order by ' + @SortOrder
else
	set @sqlorder=' order by PackName '

if len(@sqlWhere)>0
	set @sql=@sql + @sqlwhere 

if len(@sqlwherebykeys)>0
begin
	
	set @sql=@sql + ' and ' + @sqlwherebykeys

end

set @sql=@sql ++ @sqlorder
--select @sql

if len(@ApplicationName)=0 and len(@VendorName)=0
	exec sp_executesql @sql
else
begin
	if len(@VendorName)=0
	begin
		EXECUTE sp_executesql @SQL, @ParmDefinitionApp,
                      @ApplicationNamePar = @ApplicationName
		return
	end
	if len(@ApplicationName)=0
	begin
		EXECUTE sp_executesql @SQL, @ParmDefinitionVnd,
                      @VendorNamePar=@VendorName
		return
	end
	EXECUTE sp_executesql @SQL, @ParmDefinitionBoth,
                      @ApplicationNamePar = @ApplicationName,
					  @VendorNamePar=@VendorName
end
GO
/****** Object:  StoredProcedure [dbo].[InsertErrorInformation]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*PROCEDURE NAME:    InsertErrorInformation
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Insert information about errors generated on system server site
Return Values:
0 - success
-1 - db error 

PARAMETERS:
@UserLogin varchar(30),
@ErrSource varchar(500),
@ErrMessage varchar(1000),
@ErrorID int output  -- 0 if db error happened
@DBErrMsg varchar(500) output

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/
CREATE procedure [dbo].[InsertErrorInformation]
@ErrSource varchar(500),
@ErrMessage varchar(1000),
@DBErrMsg varchar(500) output
as
declare @RET_SUCCESS smallint,@RET_DB_ERROR smallint,@ReturnValue smallint

set @RET_SUCCESS=0
set @RET_DB_ERROR=-1

set @ReturnValue=@RET_SUCCESS

begin try

	insert into ErrorLog(ErrSource,ErrMessage,CreatedDAteTime)
	values (@ErrSource,@ErrMessage,GetDate())
	
end try
begin catch

	set @ReturnValue=@RET_DB_ERROR
	set @DBErrMsg=ERROR_MESSAGE()
end catch

Return @ReturnValue
GO
/****** Object:  StoredProcedure [dbo].[ManagementPackDependenciesGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[ManagementPackDependenciesGet]
(
     @ManagementPackXml            xml               --INPUT Management Packs whose information is to be returned
    ,@ProductName                  nvarchar(1024)    -- INPUT expects Product name of the client
    ,@ProductVersion               nvarchar(25)      -- INPUT expects Product version of the client
)
AS


/****************************************************************************

PROCEDURE NAME: ManagementPackExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to return the direct and indirect dependencies
of a given set of management packs.

Sample Xml for ManagementPackXml
<ManagementPacks>
<ManagementPack VersionIndependentGuid="version_independent_guid1" Version="6.0.6278.0" />
<ManagementPack VersionIndependentGuid="version_independent_guid2" Version="6.0.6278.10" />
</ManagementPacks>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/29/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
    ,@XmlDocHandle    int
    ,@ExecResult      int

  SET @ErrorInd = 0

  BEGIN TRY


  -- Create temp table   
  CREATE TABLE #ManagementPack (
    VersionIndependentGuid uniqueidentifier
  )
  

  IF @ManagementPackXml IS NOT NULL 
  BEGIN
    -- Read the Xml
       EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @ManagementPackXml
       IF @ExecResult <> 0 RAISERROR('TODO: Fix this error message',16, 1, @ExecResult)


    -- Populate temp table 
    INSERT #ManagementPack(VersionIndependentGuid)
      SELECT VersionIndependentGuid FROM OPENXML (@XmlDocHandle, '/ManagementPacks/ManagementPack',1) WITH (VersionIndependentGuid uniqueidentifier)
  END



  -- Create dependencies table
  CREATE TABLE #ManagementPackDependencies
  (
     BaseMpVersionIndependentGuid      uniqueidentifier
    ,BaseMpVersion                     varchar(32)
    ,DependentMpVersionIndependentGuid uniqueidentifier
    ,DependentMpVersion                varchar(32)
    ,Depth                             int
  )

  
  DECLARE 
    @Depth  int
    
  set @Depth = 1
  
  WHILE EXISTS(Select * from #ManagementPack)
  BEGIN

  
    --Get the latest version of the CurrentMP and their dependencies
   INSERT #ManagementPackDependencies(BaseMpVersionIndependentGuid,BaseMpVersion,DependentMpVersionIndependentGuid,DependentMpVersion,Depth)
    SELECT 
       m.VersionIndependentGuid
      ,m.Version
      ,dep.DependentMpVersionIndependentGuid
      ,dep.DependentMpVersion
      ,@Depth
    FROM
      #ManagementPack AS c
        JOIN CatalogManagementPack AS m ON c.VersionIndependentGuid = m.VersionIndependentGuid
        JOIN CatalogItem AS ci ON ci.CatalogItemId = m.CatalogItemId and PublishedInd = 'true'
        JOIN CatalogManagementPackDependency AS dep ON m.CatalogItemId = dep.ManagementPackCatalogItemId
        JOIN CatalogProductCatalogItem AS pc ON m.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
    WHERE
      NOT EXISTS (SELECT BaseMpVersionIndependentGuid FROM #ManagementPackDependencies where BaseMpVersionIndependentGuid = m.VersionIndependentGuid) 


	DELETE FROM #ManagementPack
	
   INSERT #ManagementPack(VersionIndependentGuid)
	SELECT DISTINCT(DependentMpVersionIndependentGuid)FROM #ManagementPackDependencies Where Depth = @Depth
	
	set @Depth = @Depth + 1
 
  END
  

  
  -- Output Management Pack Dependencies
  SELECT BaseMpVersionIndependentGuid,BaseMpVersion,DependentMpVersionIndependentGuid,DependentMpVersion FROM #ManagementPackDependencies

  SELECT VersionIndependentGuid, Version FROM CatalogManagementPack as m WHERE EXISTS ( SELECT * FROM #ManagementPackDependencies as d WHERE m.VersionIndependentGuid = d.DependentMpVersionIndependentGuid AND m.VersionIndependentGuid <> d.BaseMpVersionIndependentGuid)

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- Cleanup

  IF (@XmlDocHandle IS NOT NULL)
    EXEC sp_xml_removedocument @XmlDocHandle


  IF (OBJECT_ID('#ManagementPack') IS NOT NULL)
    DROP TABLE #ManagementPack

  IF (OBJECT_ID('#ManagementPackDependencies') IS NOT NULL)
    DROP TABLE #ManagementPackDependencies

  IF (OBJECT_ID('#TempManagementPackDependencies') IS NOT NULL)
    DROP TABLE #TempManagementPackDependencies


  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[ManagementPackExtendedInfoGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[ManagementPackExtendedInfoGet]
(
     @ManagementPackXml           xml              --INPUT Management Packs whose information is to be returned
    ,@ProductName                 nvarchar(1024)   -- INPUT expects Product name of the client
    ,@ProductVersion              nvarchar(25)     -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode     char(3) = 'ENU'  -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd  bit = NULL       -- INPUT expects indicator on whether to include unpublished items
)
AS

/****************************************************************************

PROCEDURE NAME: ManagementPackExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to retrieve extended Management Packs information given management pack identities.
It returns management packs and their immidiate dependencies.

Sample Xml for ManagementPackXml
<ManagementPacks>
<ManagementPack VersionIndependentGuid="version_independent_guid1" Version="6.0.6278.0" />
<ManagementPack VersionIndependentGuid="version_independent_guid2" Version="6.0.6278.10" />
</ManagementPacks>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/28/2008       maaakash      Created Stored Procedure.

****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
    ,@XmlDocHandle    int
    ,@ExecResult      int

  SET @ErrorInd = 0

  BEGIN TRY

  -- Handle parameters
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')


  -- Create temp table   
  CREATE TABLE #ManagementPack (
    VersionIndependentGuid uniqueidentifier
   ,Version                varchar(32)
  )
  

  IF @ManagementPackXml IS NOT NULL 
  BEGIN
    -- Read the Xml
       EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @ManagementPackXml
       IF @ExecResult <> 0 RAISERROR('TODO: Fix this error message',16, 1, @ExecResult)


    -- Populate temp table 
    INSERT #ManagementPack(VersionIndependentGuid, Version)
      SELECT VersionIndependentGuid, Version FROM OPENXML (@XmlDocHandle, '/ManagementPacks/ManagementPack',1) WITH (VersionIndependentGuid uniqueidentifier, Version varchar(32))
  END


  -- Create the result MP Table
  CREATE TABLE #ManagementPackResult
  (
    CatalogItemId           int
   ,Description             nvarchar(MAX)
   ,Knowledge               nvarchar(MAX)
   ,Eula                    nvarchar(MAX)
   ,PublishedInd            bit
   ,VersionIndependentGuid  uniqueidentifier
   ,Version                 nvarchar(25)
  )

  -- Populate MP Result Table 
  INSERT #ManagementPackResult(CatalogItemId,Description,Knowledge,Eula,PublishedInd,VersionIndependentGuid,Version)
  SELECT
     c.CatalogItemId 
    ,Description = ISNULL(LocalizedDescription, DefaultDescription)
    ,Knowledge = ISNULL(LocalizedKnowledge, DefaultKnowledge)
    ,Eula = 
            CASE WHEN EulaInd = 'true' 
              THEN
                ISNULL(LocalizedEula, DefaultEula)
              ELSE
                NULL
              END
    ,c.PublishedInd
    ,m.VersionIndependentGuid
    ,m.Version
  FROM
    CatalogItem AS c
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS m ON c.CatalogItemId = m.CatalogItemId
        LEFT JOIN CatalogManagementPackLocalized AS mloc ON m.CatalogItemId = mloc.CatalogItemId  and mloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
        JOIN #ManagementPack AS mp ON m.VersionIndependentGuid = mp.VersionIndependentGuid
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')

 

  -- Output Management Pack Results
  SELECT * FROM #ManagementPackResult
 
  -- Temp table to store dependencies
  CREATE TABLE #ManagementPackDependency
  (
     ManagementPackCatalogItemId            int
    ,DependentMpVersionIndependentGuid      uniqueidentifier
    ,DependentMpVersion                     nvarchar(25)
  )
 
  --Populate the dependency table
  INSERT #ManagementPackDependency(ManagementPackCatalogItemId,DependentMpVersionIndependentGuid,DependentMpVersion)
  SELECT 
    ManagementPackCatalogItemId
   ,DependentMpVersionIndependentGuid
   ,DependentMpVersion
  FROM
    CatalogManagementPackDependency AS dep
      JOIN #ManagementPackResult AS m ON dep.ManagementPackCatalogItemId = m.CatalogItemId

  -- Output Dependency List
  SELECT * FROM #ManagementPackDependency

  -- Output dependencies information
  SELECT
     c.CatalogItemId --CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,m.VersionIndependentGuid
    ,m.Version
    ,m.SystemName
    ,m.PublicKey
    ,m.ReleaseDate
    ,VendorName = ISNULL(LocalizedVendorName, DefaultVendorName)
    ,VendorLink = ISNULL(LocalizedVendorLink, DefaultVendorLink)
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd
    ,ThirdPartyDownloadText = ISNULL(LocalizedThirdPartyDownloadText, DefaultThirdPartyDownloadText)
    ,ThirdPartyDownloadLink = ISNULL(LocalizedThirdPartyDownloadLink, DefaultThirdPartyDownloadLink)
  FROM
    CatalogItem AS c
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS m ON c.CatalogItemId = m.CatalogItemId
        JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
        JOIN CatalogVendor AS v ON m.VendorId = v.VendorId
        LEFT JOIN CatalogVendorLocalized AS vloc on v.VendorId = vloc.VendorId
        LEFT JOIN CatalogManagementPackLocalized AS mpLoc on c.CatalogItemId = mpLoc.CatalogItemId
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')
    AND EXISTS (Select ManagementPackCatalogItemId FROM #ManagementPackDependency AS dep WHERE dep.DependentMpVersionIndependentGuid = m.VersionIndependentGuid)
  

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- Cleanup

  IF (@XmlDocHandle IS NOT NULL)
    EXEC sp_xml_removedocument @XmlDocHandle


  IF (OBJECT_ID('#ManagementPack') IS NOT NULL)
    DROP TABLE #ManagementPack

  IF (OBJECT_ID('#ManagementPackResult') IS NOT NULL)
    DROP TABLE #ManagementPackResult

  IF (OBJECT_ID('#ManagementPackDependency') IS NOT NULL)
    DROP TABLE #ManagementPackDependency



  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[ManagementPackGet]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[ManagementPackGet]
(
     @ManagementPackXml           xml              --INPUT Management Packs whose information is to be returned
    ,@ProductName                 nvarchar(1024)   -- INPUT expects Product name of the client
    ,@ProductVersion              nvarchar(25)     -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode     char(3) = 'ENU'  -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd  bit = NULL       -- INPUT expects indicator on whether to include unpublished items
)
AS
/****************************************************************************

PROCEDURE NAME: ManagementPackGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Management Packs information given management pack identities.
It returns management packs and their category ids.

Sample Xml for ManagementPackXml
<ManagementPacks>
<ManagementPack VersionIndependentGuid="version_independent_guid1" Version="6.0.6278.0" />
<ManagementPack VersionIndependentGuid="version_independent_guid2" Version="6.0.6278.10" />
</ManagementPacks>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/28/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
    ,@XmlDocHandle    int
    ,@ExecResult      int

  SET @ErrorInd = 0

  BEGIN TRY

  -- Handle parameters
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')



  -- Create temp table   
  CREATE TABLE #ManagementPack (
    VersionIndependentGuid uniqueidentifier
   ,Version                nvarchar(25)
  )
  

  IF @ManagementPackXml IS NOT NULL 
  BEGIN
    -- Read the Xml
       EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @ManagementPackXml
       IF @ExecResult <> 0 RAISERROR('TODO: Fix this error message',16, 1, @ExecResult)


    -- Populate temp table 
    INSERT #ManagementPack(VersionIndependentGuid, Version)
      SELECT VersionIndependentGuid, Version FROM OPENXML (@XmlDocHandle, '/ManagementPacks/ManagementPack',1) WITH (VersionIndependentGuid uniqueidentifier, Version nvarchar(25))
  END


  -- Create the result MP Table
  CREATE TABLE #ManagementPackResult
  (
    CatalogItemId           int
   ,DisplayName             nvarchar(1024)
   ,VersionIndependentGuid  uniqueidentifier
   ,Version                 nvarchar(25)
   ,SystemName              nvarchar(256)
   ,PublicKey               varchar(32)
   ,ReleaseDate             DateTime
   ,VendorName              nvarchar(1024)
   ,VendorLink              nvarchar(1024)
   ,DownloadUri             nvarchar(1024)
   ,EulaInd                 bit
   ,SecurityInd             bit
   ,PublishedInd            bit
   ,ThirdPartyDownloadText  nvarchar(1024)
   ,ThirdPartyDownloadLink  nvarchar(1024)
  )

  -- Populate MP Result Table 
  INSERT #ManagementPackResult(CatalogItemId,DisplayName,VersionIndependentGuid,Version,SystemName,PublicKey,ReleaseDate,VendorName,VendorLink,DownloadUri,EulaInd,SecurityInd,PublishedInd,ThirdPartyDownloadText,ThirdPartyDownloadLink)
  SELECT
     c.CatalogItemId --CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,m.VersionIndependentGuid
    ,m.Version
    ,m.SystemName
    ,m.PublicKey
    ,m.ReleaseDate
    ,VendorName = ISNULL(LocalizedVendorName, DefaultVendorName)
    ,VendorLink = ISNULL(LocalizedVendorLink, DefaultVendorLink)
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd
    ,ThirdPartyDownloadText = ISNULL(LocalizedThirdPartyDownloadText, DefaultThirdPartyDownloadText)
    ,ThirdPartyDownloadLink = ISNULL(LocalizedThirdPartyDownloadLink, DefaultThirdPartyDownloadLink)
  FROM
    CatalogItem AS c
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS m ON c.CatalogItemId = m.CatalogItemId
        JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
        JOIN CatalogVendor AS v ON m.VendorId = v.VendorId
        LEFT JOIN CatalogVendorLocalized AS vloc on v.VendorId = vloc.VendorId
        LEFT JOIN CatalogManagementPackLocalized AS mpLoc on c.CatalogItemId = mpLoc.CatalogItemId
        JOIN #ManagementPack AS mp ON m.VersionIndependentGuid = mp.VersionIndependentGuid
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')

 

  -- Output Management Pack Results
  SELECT * FROM #ManagementPackResult
 
  --Output associated categories
  SELECT 
    mc.ManagementPackCatalogItemId
   ,mc.CategoryCatalogItemId
   ,ci.PublishedInd
  FROM
    CatalogManagementPackCategory AS mc
      JOIN #ManagementPackResult AS m ON mc.ManagementPackCatalogItemId = m.CatalogItemId
      JOIN CatalogProductCatalogItem AS pc ON mc.CategoryCatalogItemId = pc.CatalogItemId
      JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
      JOIN CatalogItem AS ci ON mc.CategoryCatalogItemId = ci.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR ci.PublishedInd = 'true')




  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- Cleanup

  IF (@XmlDocHandle IS NOT NULL)
    EXEC sp_xml_removedocument @XmlDocHandle


  IF (OBJECT_ID('#ManagementPack') IS NOT NULL)
    DROP TABLE #ManagementPack

  IF (OBJECT_ID('#ManagementPackResult') IS NOT NULL)
    DROP TABLE #ManagementPackResult


  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[ManagementPackList]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[ManagementPackList]
(
     @CatalogItemId                 int = NULL              -- INPUT expects the starting category id, 0 for the root of the tree
    ,@Depth                         int = NULL              -- INPUT expects the depth to which categories should be returned
    ,@ProductName                   nvarchar(1024)          -- INPUT expects Product name of the client
    ,@ProductVersion                nvarchar(25)            -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode       char(3) = 'ENU'         -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd    bit = NULL              -- INPUT expects indicator on whether to include unpublished items
)
AS
/****************************************************************************

PROCEDURE NAME: ManagementPackList

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/02/2008

DESCRIPTION:
------------
This store procedure is used to retrieve a part of the catalog tree structure up to a given depth given a starting category catalog item id.
If CatalogItemId is 0 then it starts with the root node
If Depth is 0 then it fetches all the levels.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/02/2008       maaakash      Created Stored Procedure.
1.1         11/19/2008       maaakash      Sort result by display name.
****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    

  SET @ErrorInd = 0

  BEGIN TRY


  --Parameter handling
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)
  set @Depth = ISNULL(@Depth,0)
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')



  --Create table to store all categories needed
  CREATE TABLE #CategoryIds
  (
    CategoryId int
    ,Level     int
  )

  -- Populate initial category list
  INSERT INTO #CategoryIds VALUES (@CatalogItemId,0)

  
  -- Find Parent Categories
  EXEC CategorySubCategoryIdsGet @Depth,@ProductName,@ProductVersion,@IncludeUnpublishedItemsInd

  -- Output all categories
  EXEC dbo.CategoryGet @ThreeLetterLanguageCode


  --Create the resulting MP category map table
  CREATE TABLE #ManagementPackCategoryResult
  (
    ManagementPackCatalogItemId int
   ,CategoryCatalogItemId       int
  )

  -- Find the management packs
  INSERT INTO #ManagementPackCategoryResult
      SELECT 
         mc.ManagementPackCatalogItemId
        ,mc.CategoryCatalogItemId
      FROM
        CatalogManagementPackCategory AS mc
          JOIN CatalogProductCatalogItem AS pc ON mc.CategoryCatalogItemId = pc.CatalogItemId
          JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName AND dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
          JOIN CatalogItem AS ci ON mc.ManagementPackCatalogItemId = ci.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR ci.PublishedInd = 'true')
      WHERE
        EXISTS(Select * from #CategoryIds AS ids where ids.CategoryId = mc.CategoryCatalogItemId)

  -- Display the mapping between categories and management packs
  SELECT * from #ManagementPackCategoryResult    

  -- Output Management Packs
  SELECT
     c.CatalogItemId --CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,m.VersionIndependentGuid
    ,m.Version
    ,m.SystemName
    ,m.PublicKey
    ,m.ReleaseDate
    ,VendorName = ISNULL(LocalizedVendorName, DefaultVendorName)
    ,VendorLink = ISNULL(LocalizedVendorLink, DefaultVendorLink)
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd
    ,ThirdPartyDownloadText = ISNULL(LocalizedThirdPartyDownloadText, DefaultThirdPartyDownloadText)
    ,ThirdPartyDownloadLink = ISNULL(LocalizedThirdPartyDownloadLink, DefaultThirdPartyDownloadLink)
  FROM
    CatalogItem AS c
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS m ON c.CatalogItemId = m.CatalogItemId
        JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
        JOIN CatalogVendor AS v ON m.VendorId = v.VendorId
        LEFT JOIN CatalogVendorLocalized AS vloc on v.VendorId = vloc.VendorId
        LEFT JOIN CatalogManagementPackLocalized AS mpLoc on c.CatalogItemId = mpLoc.CatalogItemId
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')
    AND EXISTS (Select ManagementPackCatalogItemId from #ManagementPackCategoryResult as i where i.ManagementPackCatalogItemId = c.CatalogItemId)
  ORDER BY
    DisplayName


  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- Cleanup

  IF (OBJECT_ID('#CategoryIds') IS NOT NULL)
    DROP TABLE #CategoryIds


  IF (OBJECT_ID('#ManagementPackIdsCategoryResult') IS NOT NULL)
    DROP TABLE #ManagementPackCategoryResult


  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[ManagementPackSearch]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[ManagementPackSearch]
(
     @ManagementPackNamePattern     nvarchar(1024) = NULL   -- INPUT expects MP or category name search pattern
    ,@VendorNamePattern             nvarchar(1024) = NULL   -- INPUT expects Vendor name search pattern
    ,@ReleasedOnOrAfter             datetime = NULL         -- INPUT expects filtering date for MPs
    ,@InstalledManagementPackXml    xml = NULL              -- INPUT expects xml to represent installed MPs, see description for sample
    ,@ProductName                   nvarchar(1024)          -- INPUT expects Product name of the client
    ,@ProductVersion                nvarchar(25)            -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode       char(3) = 'ENU'         -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd    bit = NULL              -- INPUT expects indicator on whether to include unpublished items
)
AS

/****************************************************************************

PROCEDURE NAME: ManagementPackSearch

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Management Packs satisfying the given criteria and associated categories.

Sample Xml for InstalledManagementPackXml
<ManagementPacks>
<ManagementPack VersionIndependentGuid="version_independent_guid1" Version="6.0.6278.0" />
<ManagementPack VersionIndependentGuid="version_independent_guid2" Version="6.0.6278.10" />
</ManagementPacks>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/28/2008       maaakash      Created Stored Procedure.
1.1         11/19/2008       maaakash      Sort result by display name and also search category name for management pack name pattern.
****************************************************************************/

BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
    ,@XmlDocHandle    int
    ,@ExecResult      int

  SET @ErrorInd = 0

  BEGIN TRY


  --Parameter handling
  
  set @ManagementPackNamePattern = ISNULL(@ManagementPackNamePattern,'%')
  set @VendorNamePattern = ISNULL(@VendorNamePattern,'%')
  set @ReleasedOnOrAfter = ISNULL(@ReleasedOnOrAfter,0)
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')


  -- Create temp table   
  CREATE TABLE #InstalledManagementPack (
    VersionIndependentGuid uniqueidentifier
   ,Version                nvarchar(25)
  )
  

  IF @InstalledManagementPackXml IS NOT NULL 
  BEGIN
    -- Read the Xml
       EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @InstalledManagementPackXml
       IF @ExecResult <> 0 RAISERROR('TODO: Fix this error message',16, 1, @ExecResult)


    -- Populate temp table 
    INSERT #InstalledManagementPack(VersionIndependentGuid, Version)
      SELECT VersionIndependentGuid, Version FROM OPENXML (@XmlDocHandle, '/ManagementPacks/ManagementPack',1) WITH (VersionIndependentGuid uniqueidentifier, Version nvarchar(25))
  END



  -- Create table to store all matching categories
  CREATE TABLE #CategoryIds
  (
    CategoryId int
    ,Level     int
  )

  --Add all matching category information
  INSERT #CategoryIds(CategoryId,Level)
  SELECT
    c.CatalogItemId
    ,0
  FROM 
    CatalogItem as c
      LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
      JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
      JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')
    AND ISNULL(LocalizedDisplayName,DefaultDisplayName) LIKE @ManagementPackNamePattern COLLATE SQL_Latin1_General_CP1_CI_AS
    AND IsCategory = 'true'

  -- Get all sub categories of matching categories
  EXEC CategorySubCategoryIdsGet 0,@ProductName,@ProductVersion,@IncludeUnpublishedItemsInd

  -- Create table to store all MP ids matching categories
  CREATE TABLE #CategoryManagementPackIds
  (
    ManagementPackId int
  )

  --Insert MP id information
  INSERT #CategoryManagementPackIds(ManagementPackId)
  SELECT DISTINCT(ManagementPackCatalogItemId)
    FROM 
      CatalogManagementPackCategory AS cmp
      JOIN #CategoryIds AS cid ON (cid.CategoryId = cmp.CategoryCatalogItemId)


  -- Create the result MP Table
  CREATE TABLE #ManagementPackResult
  (
    CatalogItemId           int
   ,DisplayName             nvarchar(1024)
   ,VersionIndependentGuid  uniqueidentifier
   ,Version                 nvarchar(25)
   ,SystemName              nvarchar(256)
   ,PublicKey               varchar(32)
   ,ReleaseDate             DateTime
   ,VendorName              nvarchar(1024)
   ,VendorLink              nvarchar(1024)
   ,DownloadUri             nvarchar(1024)
   ,EulaInd                 bit
   ,SecurityInd             bit
   ,PublishedInd            bit
   ,ThirdPartyDownloadText  nvarchar(1024)
   ,ThirdPartyDownloadLink  nvarchar(1024)
  )


 -- Populate MP Result Table 
  INSERT #ManagementPackResult(CatalogItemId,DisplayName,VersionIndependentGuid,Version,SystemName,PublicKey,ReleaseDate,VendorName,VendorLink,DownloadUri,EulaInd,SecurityInd,PublishedInd,ThirdPartyDownloadText,ThirdPartyDownloadLink)
  SELECT
     c.CatalogItemId --CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,m.VersionIndependentGuid
    ,m.Version
    ,m.SystemName
    ,m.PublicKey
    ,m.ReleaseDate
    ,VendorName = ISNULL(LocalizedVendorName, DefaultVendorName)
    ,VendorLink = ISNULL(LocalizedVendorLink, DefaultVendorLink)
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd
    ,ThirdPartyDownloadText = ISNULL(LocalizedThirdPartyDownloadText, DefaultThirdPartyDownloadText)
    ,ThirdPartyDownloadLink = ISNULL(LocalizedThirdPartyDownloadLink, DefaultThirdPartyDownloadLink)
  FROM
    CatalogItem AS c
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS m ON c.CatalogItemId = m.CatalogItemId
        JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
        JOIN CatalogVendor AS v ON m.VendorId = v.VendorId
        LEFT JOIN CatalogVendorLocalized AS vloc on v.VendorId = vloc.VendorId
        LEFT JOIN CatalogManagementPackLocalized AS mpLoc on c.CatalogItemId = mpLoc.CatalogItemId
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')
    AND ISNULL(LocalizedVendorName, DefaultVendorName) LIKE @VendorNamePattern COLLATE SQL_Latin1_General_CP1_CI_AS
    AND (ISNULL(LocalizedDisplayName, DefaultDisplayName) LIKE @ManagementPackNamePattern COLLATE SQL_Latin1_General_CP1_CI_AS OR EXISTS ( SELECT * from #CategoryManagementPackIds AS cmp WHERE cmp.ManagementPackId = c.CatalogItemId ) )
    AND m.ReleaseDate >= @ReleasedOnOrAfter
    AND 
      (
        @InstalledManagementPackXml IS NULL 
        OR
        EXISTS (Select i.Version from #InstalledManagementPack as i where i.VersionIndependentGuid = m.VersionIndependentGuid AND dbo.fn_VersionCompare(m.Version,i.Version) = 1)
      )


  DELETE FROM #CategoryIds

  DROP TABLE #CategoryManagementPackIds

  -- Output Management Pack Results
  SELECT * FROM #ManagementPackResult ORDER BY DisplayName
 
 
  --Create the resulting MP category map table
  CREATE TABLE #ManagementPackCategoryResult
  (
    ManagementPackCatalogItemId int
   ,CategoryCatalogItemId       int
  )
 
  INSERT #ManagementPackCategoryResult(ManagementPackCatalogItemId,CategoryCatalogItemId)
  SELECT 
    mc.ManagementPackCatalogItemId
   ,mc.CategoryCatalogItemId
  FROM
    CatalogManagementPackCategory AS mc
      JOIN #ManagementPackResult AS m ON mc.ManagementPackCatalogItemId = m.CatalogItemId
      JOIN CatalogProductCatalogItem AS pc ON mc.CategoryCatalogItemId = pc.CatalogItemId
      JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) <= 0
      JOIN CatalogItem AS ci ON mc.CategoryCatalogItemId = ci.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR ci.PublishedInd = 'true')
          
  -- Output MP Category Map Table
  SELECT * FROM #ManagementPackCategoryResult



  -- Populate initial category list
  INSERT #CategoryIds(CategoryId,Level)
    SELECT 
      DISTINCT(CategoryCatalogItemId)
      ,0 
    FROM 
      #ManagementPackCategoryResult AS m
        JOIN CatalogItem AS c ON m.CategoryCatalogItemId = c.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR c.PublishedInd = 'true')


  -- Find Parent Categories
  EXEC CategoryParentIdsGet 0,@ProductName,@ProductVersion,@IncludeUnpublishedItemsInd

  -- Output all categories
  EXEC dbo.CategoryGet @ThreeLetterLanguageCode


  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- Cleanup

  IF (@XmlDocHandle IS NOT NULL)
    EXEC sp_xml_removedocument @XmlDocHandle


  IF (OBJECT_ID('#InstalledManagementPack') IS NOT NULL)
    DROP TABLE #InstalledManagementPack

  IF (OBJECT_ID('#ManagementPackResult') IS NOT NULL)
    DROP TABLE #ManagementPackResult

  IF (OBJECT_ID('#ManagementPackCategoryResult') IS NOT NULL)
    DROP TABLE #ManagementPackCategoryResult

  IF (OBJECT_ID('#CategoryIds') IS NOT NULL)
    DROP TABLE #CategoryIds


  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO
/****** Object:  StoredProcedure [dbo].[SaveAllPackDataByPackID]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************************************
PROCEDURE NAME:    SaveAllPackDataByPackID
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Insert/updates data in Pack,PackProducts and PackLocalizedData.
Data is transfered from Admin database in form of one or two xmls.
RETURN VALUES:
0 - success
-1 - db error 
-2 - error in xml
-4 - wrong packid is provided

PARAMETERS:
@PackId int, 
@IsPreview tinyint, -- 1 - record will be used only in preview mode from staging server,0-production
@XMLMainData nvarchar(4000) xml should be formatted as below:
<packM pid="264" pVer="www" pName="some new name2" aName="some app name2" dURL="somed url2" desc="some desc2" vName="vendor name2" vURL="vendor url2" uDate="2007-08-12T00:00:00" isAct="0" pDate="2100-01-01T00:00:00" eDate="2007-08-07T12:08:06.717" eBy="v-galkom"><product prodID="3"/><product prodID="4"/></packM>

@XMLLocData nvarchar(max) xml should be formatted as below:
<packL pid="264"><locData pVerL="www" lcid="1031" pNameL="dd" aNameL="ddd" dURLL="www" descL="www" eDate="2007-08-07T00:00:00" eBy="v-galkom"/><locData lcid="1032" pNameL="some new name2" aNameL="some app name2" dURLL="somed url2" descL="some desc" eDate="2007-08-07T12:08:06.717" eBy="v-galkom"/></packL>

@ErrMsg nvarchar(500) output

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/
CREATE procedure [dbo].[SaveAllPackDataByPackID]
@PackId int,
@IsPreview bit,
@XMLMainData nvarchar(4000), 
@XMLLocData nvarchar(max),
@ErrMsg nvarchar(500) output
as

declare @RET_SUCCESS smallint,@RET_DB_ERROR smallint, @RET_XML_ERROR smallint
declare @RET_RECORD_WAS_EDITED smallint, @RET_RECORD_DOES_NOT_EXIST smallint,@RET_USER_DOES_NOT_HAVE_RIGHTS smallint

set @RET_SUCCESS=0
set @RET_DB_ERROR=-1
set @RET_XML_ERROR=-2
set @RET_RECORD_WAS_EDITED=-3
set @RET_RECORD_DOES_NOT_EXIST=-4
set @RET_USER_DOES_NOT_HAVE_RIGHTS=-5

declare @UNPUBLISH_DATE nvarchar(8)
set @UNPUBLISH_DATE='1/1/2100'

declare @ReturnValue smallint
set @ReturnValue=@RET_SUCCESS

-- main data
declare @PackVersion nvarchar(40),@MainPackId int,@PackName nvarchar(100), @ApplicationName nvarchar(100),@DownloadURL varchar(500),@Description nvarchar(2000)
declare @VendorName nvarchar(100),@VendorURL varchar(500),@IsActive tinyint,@UpdatedDateTime varchar(30)
declare @PublishedDateTime varchar(30),@PublishedBy varchar(30),@LastEditedDateTime varchar(30),@LastEditedBy varchar(30)

-- loc data
declare @LocalizedData table(id smallint identity,packID int,lcid int,PackVersionLoc nvarchar(40),PackNameLoc nvarchar(100),ApplicationNameLoc nvarchar(100),DownloadURLLoc varchar(500),DescriptionLoc nvarchar(2000),LastEditedDateTime datetime,LastEditedBy varchar(30),LastUpdatedDateTimeLoc datetime)

-- products
declare @Products table(id smallint identity,ProductID smallint)

declare @hDoc int
-- parse xml's first and save data in variables
if (len(@XMLMainData) >0)
begin
	begin try 
		exec sp_xml_preparedocument @hDoc OUTPUT, @XMLMainData

		select 
			@MainPackID = ISNULL(XMLPackID,0),
			@PackVersion=XMLPackVersion,
			@PackName = rtrim(ISNULL(XMLPackName,'')),
			@ApplicationName = rtrim(ISNULL(XMLApplicationName,'')),
			@DownloadURL=rtrim(ISNULL(XMLDownloadURL,'')),
			@Description=rtrim(ISNULL(XMLDescription,'')),
			@VendorName=rtrim(ISNULL(XMLVendorName,'')),
			@VendorURL=rtrim(ISNULL(XMLVendorURL,'')),
			@VendorName=rtrim(ISNULL(XMLVendorName,'')),
			@IsActive=rtrim(ISNULL(XMLIsActive,0)),
			@UpdatedDateTime=rtrim(ISNULL(XMLUpdatedDateTime,'')),
			@PublishedDateTime=rtrim(ISNULL(XMLPublishedDateTime,'')),
			@PublishedBy=rtrim(ISNULL(XMLPublishedBy,'')),
			@LastEditedDateTime=rtrim(ISNULL(XMLEditedDateTime,'')),
			@LastEditedBy=rtrim(ISNULL(XMLEditedBy,''))
			from OPENXML(@hDoc, N'packM')
		with 
		( 
			XMLPackVersion nvarchar(40) '@pVer',
			XMLPackID int '@pid',
			XMLPackName nvarchar(100) '@pName',
			XMLApplicationName nvarchar(100) '@aName',
			XMLDownloadURL varchar(500) '@dURL',
			XMLDescription nvarchar(2000) '@desc',
			XMLVendorName nvarchar(100) '@vName',
			XMLVendorURL varchar(500) '@vURL',
			XMLIsActive tinyint '@isAct',
			XMLUpdatedDateTime varchar(30) '@uDate',
			XMLPublishedDateTime varchar(30) '@pDate',
			XMLPublishedBy varchar(30) '@pBy',
			XMLEditedDateTime varchar(30) '@eDate',
			XMLEditedBy varchar(30) '@eBy'
		)

		select @PackVersion=replace(@PackVersion,'~',' ')
		-- products
		insert into @Products (ProductID) 
		select 
			XMLProductID 
			from OPENXML(@hDoc, N'packM/product')
		with 
		( 
			XMLProductID smallint '@prodID'
		)
		-- Clear the XML document FROM memory
		exec sp_xml_removedocument @hDoc

		if len(@XMLLocData)>0
		begin
			exec sp_xml_preparedocument @hDoc OUTPUT, @XMLLocData
			insert into @LocalizedData (packID,PackVersionLoc,lcid,PackNameLoc,ApplicationNameLoc,DownloadURLLoc,DescriptionLoc,LastEditedDateTime,LastEditedBy,LastUpdatedDAteTimeLoc)
			select 
				XMLPackID,
				XMLPackVersionLoc,
				ISNULL(XMLlcid,0),
				rtrim(ISNULL(XMLPackNameLoc,'')),
				rtrim(ISNULL(XMLApplicationNameLoc,'')),
				rtrim(ISNULL(XMLDownloadURLLoc,'')),
				rtrim(ISNULL(XMLDescriptionLoc,'')),
				rtrim(ISNULL(XMLEditedDateTime,'')),
				rtrim(ISNULL(XMLEditedBy,'')),
				rtrim(ISNULL(XMLUpdatedDateTime,''))
				from OPENXML(@hDoc, N'packL/locData')
			with 
			( 
				XMLPackId int '@pidL',
				XMLPackVersionLoc nvarchar(40) '@pVerL',
				XMLPackNameLoc nvarchar(100) '@pNameL',
				XMLApplicationNameLoc nvarchar(100) '@aNameL',
				XMLDownloadURLLoc varchar(500) '@dURLL',
				XMLDescriptionLoc nvarchar(2000) '@descL',
				XMLlcid int '@lcid',
				XMLEditedDateTime varchar(30) '@eDate',
				XMLEditedBy varchar(30) '@eBy',
				XMLUpdatedDateTime varchar(30) '@uDateL'
			)
			update @LocalizedData set PackVersionLoc=replace(PackVersionLoc,'~',' ')

			exec sp_xml_removedocument @hDoc
		end
	end try
	begin catch
		set @ReturnValue=@RET_XML_ERROR
		set @ErrMsg=ERROR_MESSAGE()
		goto final
	end catch

	-- check for required fields
	if (((@IsPreview=0) and (@PublishedDateTime=@UNPUBLISH_DATE)) or (@MainPackID<>@PackID) or (len(@PackName) =0 or len(@ApplicationName) =0 or len(@VendorName)=0 or len(@VendorURL) =0 or len(@UpdatedDateTime) =0 or len(@Description) =0 or len(@PublishedDateTime)  =0) or ((select count(*) from @products)=0) or (exists(select 1 from @localizeddata where (packid<>@PackID) or (len(PackNameLoc) =0 or len(ApplicationNameLoc) =0 or len(downloadURLLOc) =0 or len(LastUpdateddatetimeLoc) =0 or Len(descriptionLoc)=0))))
	begin
		set @ReturnValue=@RET_XML_ERROR
		set @ErrMsg='One or more of required field were not provided or wrong'
		goto final
	end

end

begin tran
begin try
	delete from PackLocalizedData where PackIDLoc=@PackID and IsPreviewLoc=@IsPreview
	delete from PackProducts where PackIDProd=@PackID and IsPReviewProd=@IsPreview
	delete from Pack where PackId=@PackID and IsPreview=@IsPreview

	insert into pack(PackID,PackVersion,IsPreview,PublishedDateTime,PackName,ApplicationName,DownloadURL,Description,VendorName,VendorURL,LastUpdatedDateTime,LastEditedDateTime,LastEditedBy,IsPackActive,PublishedBy)
	values(@PackID,@PackVersion,@IsPreview,@PublishedDateTime,@PackName,@ApplicationName,@DownloadURL,@Description,@VendorName,@VendorURL, @UpdatedDAteTime,@LastEditedDateTime,@LastEditedby,@IsActive,@PublishedBy)
	
	insert into packproducts(PackIDPRod,IsPreviewProd,ProductID_FK)
	select @PackID,@IsPreview,ProductID from @PRoducts

	if len(@XMLLocData)>0
	begin
		insert into PackLocalizedData(PackIDLoc,PackVersionloc,LCID_FK,IsPreviewLoc,PackNameLoc,ApplicationNameLoc,DownloadURLLoc,DescriptionLoc,LastEditedDateTime,LastEditedBy,LastUpdatedDateTimeLoc)
		select @PackID,PackVersionLoc,lcid,@IsPreview,PackNameLoc,ApplicationNameLoc,DownLoadURLLoc,DescriptionLoc,LastEditedDateTime,LastEditedBy,LastUpdatedDAteTimeLoc from @LocalizedData     
	end
end try
begin catch
	rollback tran
	set @ReturnValue=@RET_DB_ERROR
	set @ErrMsg=ERROR_MESSAGE()
	goto final
end catch

commit tran

goto final

Final:
return @ReturnValue
GO
/****** Object:  StoredProcedure [dbo].[SaveCustomerFeedbackInformation]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************************************
PROCEDURE NAME:    SaveCustomerFeedbackInformation
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Insert record with data collected when customer fills feedback form
Table used: PackFeedback 

RETURN VALUES:
0 - success
-1 - db error 
-4 - wrong packid or productid was provided
-6 - one of required params is null

PARAMETERS:
@PackId int, -- pack with this id should exists in pack table and record should have isPreview=0
@ProductId smallint, -- product should exists in product table
@TimeOfUsage char(5), -- required field not null
@MeetNeedsGrade tinyint, -- required field not null
@SatisfactionGrade tinyint, -- required field not null
@Reason nvarchar(2000), 
@Improvements nvarchar(2000),
@ErrMsg nvarchar(500) output

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/

CREATE procedure [dbo].[SaveCustomerFeedbackInformation]
@PackId int,
@ProductId smallint,
@TimeOfUsage char(5),
@MeetNeedsGrade tinyint,
@SatisfactionGrade tinyint,
@Reason nvarchar(2000),
@Improvements nvarchar(2000),
@HexPUID varchar(25),
@ErrMsg nvarchar(500) output
as

declare @RET_SUCCESS smallint,@RET_DB_ERROR smallint, @RET_RECORD_DOES_NOT_EXIST smallint,@RET_WRONG_PARAM_VALUE smallint
set @RET_WRONG_PARAM_VALUE=-6
set @RET_SUCCESS=0
set @RET_DB_ERROR=-1
set @RET_RECORD_DOES_NOT_EXIST=-4

declare @ReturnValue smallint
set @ReturnValue=@RET_SUCCESS

if (not exists(select 1 from packproducts where productid_fk=@productID and packidprod=@packId and isPreviewProd=0) or (not exists(select 1 from pack where packid=@packid and isPreview=0)))
begin
	set @ReturnVAlue=@RET_RECORD_DOES_NOT_EXIST
	goto final
end
if ((@TimeOfUsage is null) or (@MeetNeedsGrade is null) or (@SatisfactionGrade is null)) 
begin
	set @ReturnValue=@RET_WRONG_PARAM_VALUE
	goto Final
end
 
begin try
	insert into PackFeedback (PackID_Feedback,ProductID_Feedback,TimeOfUsage,MeetNeedsGrade,SatisfactionGrade,Reason,Improvements,CreatedDateTime,HexPUID)
	values(@PackID,@ProductID,@TimeOfUsage,@MeetNeedsGrade,@SatisfactionGrade,@Reason,@Improvements,GetDate(),@HexPUID)
    
end try
begin catch
	set @ReturnVAlue=@RET_DB_ERROR
	set @ErrMsg=ERROR_MESSAGE()
	goto final
end catch

Final:
return @ReturnValue
GO
/****** Object:  StoredProcedure [dbo].[TruncateErrorLog]    Script Date: 6/15/2021 11:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*PROCEDURE NAME:    TruncateErrorLog
AUTHOR:            Galina Komissarchik (v-galkom)
DATE:              2007-8-7

DESCRIPTION:
Truncates table ErrorLog

PARAMETERS:
None

HISTORY:
VERSION   UPDATED ON    BY           DESCRIPTION OF CHANGE
****************************************************************************/
Create procedure [dbo].[TruncateErrorLog]

as
Truncate table ErrorLog
GO
