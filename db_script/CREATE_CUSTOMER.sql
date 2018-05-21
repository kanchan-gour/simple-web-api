create PROCEDURE [dbo].[CREATE_CUSTOMER]  
    -- Add the parameters for the stored procedure here  
(  
     @FirstName NVarchar(50)  
    ,@LastName NVarchar(50)  
    ,@Email NVarchar(256)  
    ,@PhoneNumber  NVarchar(50)
	,@Status  NVarchar(50)  
)  
AS  
BEGIN  
    ---- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
  
    ---- Try Catch--  
    BEGIN TRY  
        BEGIN TRANSACTION  
  
        --DECLARE @CustID Bigint  
        --    SET @CustID =isnull(((SELECT max(CustID) FROM [dbo].[tblCustomer])+1),'1')  
  
        -- Insert statements for procedure here  
        INSERT INTO [dbo].[tblCustomer]([FirstName],[LastName],[Email],[PhoneNumber],[Status])  
        VALUES(@FirstName,@LastName,@Email,@PhoneNumber,@Status)  
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