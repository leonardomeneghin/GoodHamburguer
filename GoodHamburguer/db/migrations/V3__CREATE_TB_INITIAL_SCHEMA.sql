--Define Orders
CREATE TABLE [order] (
  [id_order] INT IDENTITY(1,1) NOT NULL,
  [date_order] DATETIME,
  [total_price] DECIMAL(9, 4) DEFAULT 0,
  [discount_applyed] DECIMAL(3, 2) CHECK ([discount_applyed] <= 1.00 OR [discount_applyed] < 0)

);
--orders PK
ALTER TABLE [order] ADD CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED ([id_order] ASC);

--Define ordered_item
CREATE TABLE [item_ordered](
	[id_item_ordered] INT IDENTITY(1,1) NOT NULL,
	[id_order] INT NOT NULL,
	[id_product] INT NOT NULL
);

--ordered item PK and FK to item ordered
ALTER TABLE [item_ordered] ADD CONSTRAINT [PK_id_item_ordered] PRIMARY KEY CLUSTERED ([id_item_ordered] ASC)
ALTER TABLE [item_ordered] ADD CONSTRAINT [FK_orders_item_ordered] FOREIGN KEY ([id_order]) REFERENCES [order]

--product table, pk and fk to item ordered.
CREATE TABLE [product](
	[id_product] INT IDENTITY(1,1) NOT NULL,
	[name] VARCHAR(100) NOT NULL,
	[price] DECIMAL(9, 4) DEFAULT 0,
	[id_item_type] INT NOT NULL,
	
);

ALTER TABLE [product] ADD CONSTRAINT [PK_id_product] PRIMARY KEY CLUSTERED ([id_product] ASC);
ALTER TABLE [item_ordered] ADD CONSTRAINT [FK_products_item_ordered] FOREIGN KEY ([id_product]) REFERENCES [product];

--item type table, PK and FK to product table
CREATE TABLE [item_type](
	[id_item_type] INT IDENTITY(1,1) NOT NULL,
	[item_type_name] VARCHAR(124) NOT NULL
);

ALTER TABLE [item_type] ADD CONSTRAINT [PK_id_item_type] PRIMARY KEY CLUSTERED ([id_item_type] ASC)
ALTER TABLE [product] ADD CONSTRAINT [FK_item_type_products] FOREIGN KEY (id_item_type) REFERENCES [item_type]
