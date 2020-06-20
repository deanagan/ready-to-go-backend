
-- ctrl+shift+e to execute this query

--SELECT * FROM INFORMATION_SCHEMA.TABLES
USE ReadyToGo
GO

SELECT CheckLists.Name,
       CheckLists.Description,
       Items.Name,
       ItemDetails.Description,
       CASE WHEN ItemDetails.Ready = 0 THEN 'Not Ready' ELSE 'Ready' END AS Ready,
       ItemDetails.Quantity

FROM dbo.CheckLists
INNER JOIN dbo.CheckListToItems
ON dbo.CheckLists.Id = dbo.CheckListToItems.CheckListId
INNER JOIN dbo.Items ON Items.Id = dbo.CheckListToItems.ItemId
INNER JOIN dbo.ItemDetails ON ItemDetails.Id = dbo.Items.ItemDetailId
WHERE CheckLists.Id = 1



GO
