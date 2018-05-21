create PROCEDURE [dbo].[VIEW_CUSTOMER]  
    -- Add the parameters for the stored procedure here  
    @FirstName NVarchar(50) 
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
-- Select statements for procedure here  
  
    SELECT*FROM [dbo].[tblCustomer]  
    WHERE [FirstName] = @FirstName   
END