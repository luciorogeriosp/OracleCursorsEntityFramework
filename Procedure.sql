CREATE OR REPLACE  
PROCEDURE "SP_ADDRESS_SEL"  
(  
    P_ZIPCODE IN VARCHAR2 DEFAULT NULL,  
    CURSOR_SELECT IN OU SYS_REFCURSOR  
)  
AS  
BEGIN  
    OPEN CURSOR_SELECT FOR  
    SELECT   
        ADDRESS,  
        NEIGHBORHOOD,   
        CITY,   
        STATE   
    FROM   
        TBL_ZIPCODE  
    WHERE  
        ZIPCODE = P_ZIPCODE  
END; 