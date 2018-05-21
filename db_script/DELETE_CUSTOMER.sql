create PROCEDURE [dbo].[DELETE_CUSTOMER]  
    -- Add the parameters for the stored procedure here  
      @FirstName NVarchar(50)  
AS  
BEGIN  
    ---- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
  
    ---- Try Catch--  
    BEGIN TRY  
        BEGIN TRANSACTION  
  
        -- Delete statements for procedure here  
        DELETE [dbo].[tblCustomer]  
        WHERE [FirstName] = @FirstName   
        COMMIT TRANSACTION  
    END TRY  
    BEGIN CATCH  
            DECLARE @ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;  
            SELECT @ErrorMessage =ERROR_MESSAGE(),@ErrorSeverity =ERROR_SEVERITY(),@ErrorState =ERROR_STATE();  
            RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);  
        ROLLBACK TRANSACTION  
    END CATCH  
  
END