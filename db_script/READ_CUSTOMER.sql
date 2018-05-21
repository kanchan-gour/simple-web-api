create PROCEDURE [dbo].[READ_CUSTOMER]  
    -- Add the parameters for the stored procedure here  
     @PageNo INT  
    ,@RowCountPerPage INT  
    ,@IsPaging INT  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
-- Select statements for procedure here  
  
    IF(@IsPaging = 0)  
    BEGIN  
        SELECT top(@RowCountPerPage)*FROM [dbo].[tblCustomer]  
        ORDER BY FirstName DESC  
    END  
  
    IF(@IsPaging = 1)  
    BEGIN  
        DECLARE @SkipRow INT  
        SET @SkipRow =(@PageNo - 1)* @RowCountPerPage  
  
        SELECT*FROM [dbo].[tblCustomer]  
        ORDER BY FirstName DESC  
      
        OFFSET @SkipRow ROWS FETCH NEXT @RowCountPerPage ROWS ONLY  
    END  
END  