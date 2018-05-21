create PROCEDURE [dbo].[UPDATE_CUSTOMER]  
    -- Add the parameters for the stored procedure here  
     @FirstName NVarchar(50)  
    ,@LastName NVarchar(50)  
    ,@Email NVarchar(50)  
    ,@PhoneNumber NVarchar(256)  
    ,@Status  NVarchar(50)  
AS  
BEGIN  
    ---- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
  
    ---- Try Catch--  
    BEGIN TRY  
        BEGIN TRANSACTION  
  
        -- Update statements for procedure here  
        UPDATE [dbo].[tblCustomer]  
        SET [LastName] = @LastName,  
            [PhoneNumber] = @PhoneNumber,  
            [Status] = @Status  
        WHERE [FirstName] = @FirstName AND [Email] = @Email  
        SELECT 1  
        COMMITTRANSACTION  
    END TRY  
    BEGIN CATCH  
            DECLARE @ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;  
            SELECT @ErrorMessage =ERROR_MESSAGE(),@ErrorSeverity =ERROR_SEVERITY(),@ErrorState =ERROR_STATE();  
            RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);  
        ROLLBACK TRANSACTION  
    END CATCH  
  
END