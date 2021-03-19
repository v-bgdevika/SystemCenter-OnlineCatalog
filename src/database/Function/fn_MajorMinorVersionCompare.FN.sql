   IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.fn_MajorMinorVersionCompare') and xtype in (N'FN', N'IF', N'TF'))
    EXECUTE('CREATE FUNCTION dbo.fn_MajorMinorVersionCompare() RETURNS tinyint AS BEGIN RETURN NULL END')
  GO

  ALTER FUNCTION dbo.fn_MajorMinorVersionCompare
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
    