
-- ctrl+shift+e to execute this query

SELECT * FROM INFORMATION_SCHEMA.TABLES
USE ReadyToGo
GO

SELECT CheckLists.Name
        , CheckLists.Description
        , Items.Name
        , Items.Description
        , ItemDetails.Notes
        , CASE WHEN ItemDetails.Ready = 0 THEN 'Not Ready' ELSE 'Ready' END AS Ready
        , ItemDetails.Quantity

FROM CheckLists
INNER JOIN CheckListToItemDetails
ON CheckLists.Id = CheckListToItemDetails.CheckListId
INNER JOIN dbo.ItemDetails ON ItemDetails.Id = CheckListToItemDetails.ItemDetailId
INNER JOIN dbo.Items ON Items.Id = ItemDetails.ItemId


SELECT * FROM Items;
SELECT * FROM ItemDetails;
SELECT * FROM CheckListToItemDetails;

GO
