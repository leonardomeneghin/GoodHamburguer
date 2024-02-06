--Define Orders
CREATE TABLE [tb_orders] (
  [id_order] INT IDENTITY(1,1) NOT NULL,
  [date_order] DATETIME,
  [total_price] DECIMAL(9, 4) DEFAULT 0

);
--orders PK
ALTER TABLE [tb_orders] ADD CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED ([id_order] ASC);

--Define ordered_item
CREATE TABLE [tb_item_ordered](
	[id_item_ordered] INT IDENTITY(1,1) NOT NULL,
	[id_order] INT NOT NULL,
	[id_product] INT NOT NULL,
);

--ordered item PK and FK to item ordered
ALTER TABLE [tb_item_ordered] ADD CONSTRAINT [PK_id_item_ordered] PRIMARY KEY CLUSTERED ([id_item_ordered] ASC)
ALTER TABLE [tb_item_ordered] ADD CONSTRAINT [FK_tb_orders_tb_item_ordered] FOREIGN KEY ([id_order]) REFERENCES [tb_orders]

--product table, pk and fk to item ordered.
CREATE TABLE [tb_products](
	[id_product] INT IDENTITY(1,1) NOT NULL,
	[name] VARCHAR(100) NOT NULL,
	[price] DECIMAL(9, 4) DEFAULT 0,
	[id_item_type] INT NOT NULL,
	
);

ALTER TABLE [tb_products] ADD CONSTRAINT [PK_id_product] PRIMARY KEY CLUSTERED ([id_product] ASC);
ALTER TABLE [tb_item_ordered] ADD CONSTRAINT [FK_tb_products_tb_item_ordered] FOREIGN KEY ([id_product]) REFERENCES [tb_products];

--item type table, PK and FK to product table
CREATE TABLE [tb_item_type](
	[id_item_type] INT IDENTITY(1,1) NOT NULL,
	[item_type_name] VARCHAR(124) NOT NULL
);

ALTER TABLE [tb_item_type] ADD CONSTRAINT [PK_id_item_type] PRIMARY KEY CLUSTERED ([id_item_type] ASC)
ALTER TABLE [tb_products] ADD CONSTRAINT [FK_tb_item_type_tb_products] FOREIGN KEY (id_item_type) REFERENCES [tb_item_type]
