INSERT INTO [order] ([date_order], [total_price], [discount_applyed])
VALUES (GETDATE(), 100.00, 0.1);

DECLARE @LastOrderId INT;
SET @LastOrderId = SCOPE_IDENTITY();

-- Inserir registros na tabela [item_ordered]
-- Substitua os valores de [id_order] e [id_product] pelos valores reais
-- Certifique-se de que os valores de [id_order] correspondem ao último valor inserido na tabela [order]
INSERT INTO [item_ordered] ([id_order], [id_product])
VALUES (@LastOrderId, 1), -- Exemplo de valores, você pode ajustar conforme necessário
       (@LastOrderId, 1),
       (@LastOrderId, 3);
