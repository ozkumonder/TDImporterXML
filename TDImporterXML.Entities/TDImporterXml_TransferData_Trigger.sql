CREATE TRIGGER FillTranferData
ON MBI_TransferredData
AFTER INSERT
AS
  DECLARE @stficheref INT
  declare @nettotal float
  declare @totaldiscounts float
  DECLARE @ficheno VARCHAR(17)
  declare @tranferId int

  IF EXISTS (SELECT TransferId, TransFicheref FROM INSERTED)
  BEGIN
    SELECT @stficheref = TransFicheref,@tranferId = TransferId FROM INSERTED	
	SELECT @ficheno=STFICHE.FICHENO,@nettotal = STFICHE.NETTOTAL,@totaldiscounts=STFICHE.TOTALDISCOUNTS FROM LG_017_01_STFICHE STFICHE WHERE STFICHE.LOGICALREF = @stficheref
    UPDATE MBI_TransferredData SET FicheNo = @ficheno,NetTotal=@nettotal,TotalDiscounts=@totaldiscounts   WHERE TransferId = @tranferId
  END
GO

