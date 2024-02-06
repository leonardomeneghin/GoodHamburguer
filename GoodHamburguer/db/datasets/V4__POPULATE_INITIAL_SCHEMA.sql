--To be more fast, i will add the all needed data here.
--Products
INSERT INTO [tb_item_type] ([item_type_name])
	VALUES	('sandwich'),
			('soft drink'),
			('fries');

DECLARE @id_sandwich INT = (SELECT id_item_type FROM tb_item_type WHERE [item_type_name] = 'sandwich')
DECLARE @id_soft_drink INT = (SELECT id_item_type FROM tb_item_type WHERE [item_type_name] = 'soft drink')
DECLARE @id_fries INT = (SELECT id_item_type FROM tb_item_type WHERE [item_type_name] = 'fries')
INSERT INTO [tb_products] ([name], [price], [id_item_type])
	VALUES  ('X Burguer', 5.00, @id_sandwich),
			('X Egg', 4.50, @id_sandwich),
			('X Bacon', 7.00, @id_sandwich),
			('Fries', 2.00, @id_fries),
			('Soft drink', 2.50, @id_soft_drink);




