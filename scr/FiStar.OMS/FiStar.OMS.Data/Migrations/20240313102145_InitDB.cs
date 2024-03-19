using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiStar.OMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    country_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    currency_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currency_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    currency_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.currency_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_address_type",
                columns: table => new
                {
                    customer_address_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address_type_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_invoicing = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_address_type", x => x.customer_address_type_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_order_delivery_status",
                columns: table => new
                {
                    customer_order_delivery_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_delivery_status", x => x.customer_order_delivery_status_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_order_delivery_type",
                columns: table => new
                {
                    customer_order_delivery_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delivery_type_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    carrier_services_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_delivery_type", x => x.customer_order_delivery_type_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_order_payment_status",
                columns: table => new
                {
                    customer_order_payment_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_status_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_payment_status", x => x.customer_order_payment_status_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_order_payment_type",
                columns: table => new
                {
                    customer_order_payment_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_type_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_payment_type", x => x.customer_order_payment_type_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_order_status",
                columns: table => new
                {
                    customer_order_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_status", x => x.customer_order_status_id);
                });

            migrationBuilder.CreateTable(
                name: "eshop",
                columns: table => new
                {
                    eshop_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eshop_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    eshop_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eshop", x => x.eshop_id);
                });

            migrationBuilder.CreateTable(
                name: "item_type",
                columns: table => new
                {
                    item_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_type_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_type", x => x.item_type_id);
                });

            migrationBuilder.CreateTable(
                name: "routing_type",
                columns: table => new
                {
                    routing_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    routing_type_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routing_type", x => x.routing_type_id);
                });

            migrationBuilder.CreateTable(
                name: "system_user",
                columns: table => new
                {
                    system_user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_status = table.Column<int>(type: "int", nullable: false),
                    user_create = table.Column<int>(type: "int", nullable: false),
                    user_create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_modify = table.Column<int>(type: "int", nullable: true),
                    user_modify_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_delete = table.Column<int>(type: "int", nullable: true),
                    user_delete_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_user", x => x.system_user_id);
                });

            migrationBuilder.CreateTable(
                name: "unit_of_measure",
                columns: table => new
                {
                    unit_of_measure_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_of_measure_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    unit_of_measure_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit_of_measure", x => x.unit_of_measure_id);
                });

            migrationBuilder.CreateTable(
                name: "validate_vat_number_status",
                columns: table => new
                {
                    validate_vat_number_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_validate_vat_number_status", x => x.validate_vat_number_status_id);
                });

            migrationBuilder.CreateTable(
                name: "vat",
                columns: table => new
                {
                    vat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vat_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    vat_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    vat_rate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vat", x => x.vat_id);
                });

            migrationBuilder.CreateTable(
                name: "order_item_type",
                columns: table => new
                {
                    order_item_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_type_id = table.Column<int>(type: "int", nullable: false),
                    order_item_type_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item_type", x => x.order_item_type_id);
                    table.ForeignKey(
                        name: "FK_order_item_type_item_type",
                        column: x => x.item_type_id,
                        principalTable: "item_type",
                        principalColumn: "item_type_id");
                });

            migrationBuilder.CreateTable(
                name: "warehouse_card",
                columns: table => new
                {
                    warehouse_card_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warehouse_card_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    warehouse_card_description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    warehouse_card_type = table.Column<int>(type: "int", nullable: false),
                    warehouse_card_status = table.Column<int>(type: "int", nullable: false),
                    warehouse_card_create_user = table.Column<int>(type: "int", nullable: false),
                    warehouse_card_update_user = table.Column<int>(type: "int", nullable: false),
                    warehouse_card_delete_user = table.Column<int>(type: "int", nullable: false),
                    warehouse_card_create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    warehouse_card_update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    warehouse_card_delete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseCardCreateUserNavigationSystemUserId = table.Column<int>(type: "int", nullable: true),
                    WarehouseCardUpdateUserNavigationSystemUserId = table.Column<int>(type: "int", nullable: true),
                    WarehouseCardDeleteUserNavigationSystemUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_card", x => x.warehouse_card_id);
                    table.ForeignKey(
                        name: "FK_warehouse_card_system_user_WarehouseCardCreateUserNavigationSystemUserId",
                        column: x => x.WarehouseCardCreateUserNavigationSystemUserId,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                    table.ForeignKey(
                        name: "FK_warehouse_card_system_user_WarehouseCardDeleteUserNavigationSystemUserId",
                        column: x => x.WarehouseCardDeleteUserNavigationSystemUserId,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                    table.ForeignKey(
                        name: "FK_warehouse_card_system_user_WarehouseCardUpdateUserNavigationSystemUserId",
                        column: x => x.WarehouseCardUpdateUserNavigationSystemUserId,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    customer_company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    customer_company_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    customer_vat_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    customer_tax_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    customer_email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    customer_phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValidateVatNumberStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_customer_validate_vat_number_status",
                        column: x => x.ValidateVatNumberStatusId,
                        principalTable: "validate_vat_number_status",
                        principalColumn: "validate_vat_number_status_id");
                });

            migrationBuilder.CreateTable(
                name: "customer_address",
                columns: table => new
                {
                    customer_address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    customer_address_type_id = table.Column<int>(type: "int", nullable: false),
                    address_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    address_name1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    address_street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    address_city = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    address_district = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    address_zip = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_address", x => x.customer_address_id);
                    table.ForeignKey(
                        name: "FK_customer_address_country",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "country_id");
                    table.ForeignKey(
                        name: "FK_customer_address_customer",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_address_customer_address_type",
                        column: x => x.customer_address_type_id,
                        principalTable: "customer_address_type",
                        principalColumn: "customer_address_type_id");
                });

            migrationBuilder.CreateTable(
                name: "customer_order",
                columns: table => new
                {
                    customer_order_id = table.Column<int>(type: "int", nullable: false),
                    order_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    order_status = table.Column<int>(type: "int", nullable: false),
                    order_payment_type = table.Column<int>(type: "int", nullable: false),
                    order_payment_status = table.Column<int>(type: "int", nullable: false),
                    order_payment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_delivery_after = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_delivery_by = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_delivery_type = table.Column<int>(type: "int", nullable: true),
                    order_delivery_status = table.Column<int>(type: "int", nullable: true),
                    order_date_reservation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_date_expedition = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_date_delivery = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_date_cancel = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_total_amount = table.Column<double>(type: "float", nullable: false),
                    order_currency = table.Column<int>(type: "int", nullable: false),
                    order_currency_rate = table.Column<double>(type: "float", nullable: false),
                    order_total_amount_ac = table.Column<double>(type: "float", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    customer_address_invoicing_id = table.Column<int>(type: "int", nullable: false),
                    customer_address_delivery_id = table.Column<int>(type: "int", nullable: false),
                    order_source_web = table.Column<int>(type: "int", nullable: false),
                    order_create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    order_create_user = table.Column<int>(type: "int", nullable: true),
                    order_modify = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_modify_user = table.Column<int>(type: "int", nullable: true),
                    order_delete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_delete_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order", x => x.customer_order_id);
                    table.ForeignKey(
                        name: "FK_customer_order_currency",
                        column: x => x.order_currency,
                        principalTable: "currency",
                        principalColumn: "currency_id");
                    table.ForeignKey(
                        name: "FK_customer_order_customer",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK_customer_order_customer_address_delivery",
                        column: x => x.customer_address_delivery_id,
                        principalTable: "customer_address",
                        principalColumn: "customer_address_id");
                    table.ForeignKey(
                        name: "FK_customer_order_customer_address_invoicing",
                        column: x => x.customer_address_invoicing_id,
                        principalTable: "customer_address",
                        principalColumn: "customer_address_id");
                    table.ForeignKey(
                        name: "FK_customer_order_customer_order_delivery_status",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order_delivery_status",
                        principalColumn: "customer_order_delivery_status_id");
                    table.ForeignKey(
                        name: "FK_customer_order_customer_order_delivery_type",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order_delivery_type",
                        principalColumn: "customer_order_delivery_type_id");
                    table.ForeignKey(
                        name: "FK_customer_order_customer_order_payment_status",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order_payment_status",
                        principalColumn: "customer_order_payment_status_id");
                    table.ForeignKey(
                        name: "FK_customer_order_customer_order_payment_type",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order_payment_type",
                        principalColumn: "customer_order_payment_type_id");
                    table.ForeignKey(
                        name: "FK_customer_order_customer_order_status",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order_status",
                        principalColumn: "customer_order_status_id");
                    table.ForeignKey(
                        name: "FK_customer_order_eshop",
                        column: x => x.order_source_web,
                        principalTable: "eshop",
                        principalColumn: "eshop_id");
                    table.ForeignKey(
                        name: "FK_customer_order_system_user_create",
                        column: x => x.order_create_user,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                    table.ForeignKey(
                        name: "FK_customer_order_system_user_delete",
                        column: x => x.order_delete_user,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                    table.ForeignKey(
                        name: "FK_customer_order_system_user_modify",
                        column: x => x.order_modify_user,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                });

            migrationBuilder.CreateTable(
                name: "customer_order_item",
                columns: table => new
                {
                    customer_order_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerOrderId = table.Column<int>(type: "int", nullable: false),
                    item_type_id = table.Column<int>(type: "int", nullable: false),
                    warehouse_card_id = table.Column<int>(type: "int", nullable: false),
                    order_by_item = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    quantity = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    quantity_reserved = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    quantity_delivery = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    unit_of_measure = table.Column<int>(type: "int", nullable: false),
                    unit_of_measure_base = table.Column<int>(type: "int", nullable: false),
                    unit_of_measure_ratio = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    unit_price_currency = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    unit_price_ac = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    currency_id = table.Column<int>(type: "int", nullable: false),
                    currency_ratio = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    vat_id = table.Column<int>(type: "int", nullable: false),
                    vat_rate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    discount_add_on = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    routing_type_id = table.Column<int>(type: "int", nullable: false),
                    total_price_currency = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    total_price_ac = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    total_price_vat_currency = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    total_price_vat_ac = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    order_item_create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    order_item_update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    order_item_delete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    order_item_create_user = table.Column<int>(type: "int", nullable: false),
                    order_item_update_user = table.Column<int>(type: "int", nullable: false),
                    order_item_delete_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_item", x => x.customer_order_item_id);
                    table.ForeignKey(
                        name: "FK_customer_order_item_currency",
                        column: x => x.currency_id,
                        principalTable: "currency",
                        principalColumn: "currency_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_customer_order",
                        column: x => x.CustomerOrderId,
                        principalTable: "customer_order",
                        principalColumn: "customer_order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_order_item_order_item_create_user",
                        column: x => x.order_item_create_user,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_order_item_delete_user",
                        column: x => x.order_item_delete_user,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_order_item_type",
                        column: x => x.item_type_id,
                        principalTable: "order_item_type",
                        principalColumn: "order_item_type_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_order_item_update_user",
                        column: x => x.order_item_update_user,
                        principalTable: "system_user",
                        principalColumn: "system_user_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_routing_type",
                        column: x => x.routing_type_id,
                        principalTable: "routing_type",
                        principalColumn: "routing_type_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_unit_of_measure",
                        column: x => x.unit_of_measure,
                        principalTable: "unit_of_measure",
                        principalColumn: "unit_of_measure_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_unit_of_measure_base",
                        column: x => x.unit_of_measure_base,
                        principalTable: "unit_of_measure",
                        principalColumn: "unit_of_measure_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_vat",
                        column: x => x.vat_id,
                        principalTable: "vat",
                        principalColumn: "vat_id");
                    table.ForeignKey(
                        name: "FK_customer_order_item_warehouse_card",
                        column: x => x.warehouse_card_id,
                        principalTable: "warehouse_card",
                        principalColumn: "warehouse_card_id");
                });

            migrationBuilder.CreateTable(
                name: "customer_order_sum",
                columns: table => new
                {
                    customer_order_sum_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_order_id = table.Column<int>(type: "int", nullable: false),
                    currency_id = table.Column<int>(type: "int", nullable: false),
                    vat_id = table.Column<int>(type: "int", nullable: false),
                    vat_percent = table.Column<double>(type: "float", nullable: false),
                    with_out_vat = table.Column<double>(type: "float", nullable: false),
                    vat_amount = table.Column<double>(type: "float", nullable: false),
                    with_vat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order_sum", x => x.customer_order_sum_id);
                    table.ForeignKey(
                        name: "FK_customer_order_sum_currency",
                        column: x => x.currency_id,
                        principalTable: "currency",
                        principalColumn: "currency_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_order_sum_customer_order",
                        column: x => x.customer_order_id,
                        principalTable: "customer_order",
                        principalColumn: "customer_order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_order_sum_vat",
                        column: x => x.vat_id,
                        principalTable: "vat",
                        principalColumn: "vat_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_ValidateVatNumberStatusId",
                table: "customer",
                column: "ValidateVatNumberStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_country_id",
                table: "customer_address",
                column: "country_id",
                unique: true,
                filter: "[country_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_customer_address_type_id",
                table: "customer_address",
                column: "customer_address_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_customer_id",
                table: "customer_address",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_customer_address_delivery_id",
                table: "customer_order",
                column: "customer_address_delivery_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_customer_address_invoicing_id",
                table: "customer_order",
                column: "customer_address_invoicing_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_customer_id",
                table: "customer_order",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_order_create_user",
                table: "customer_order",
                column: "order_create_user",
                unique: true,
                filter: "[order_create_user] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_order_currency",
                table: "customer_order",
                column: "order_currency",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_order_delete_user",
                table: "customer_order",
                column: "order_delete_user",
                unique: true,
                filter: "[order_delete_user] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_order_modify_user",
                table: "customer_order",
                column: "order_modify_user",
                unique: true,
                filter: "[order_modify_user] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_order_source_web",
                table: "customer_order",
                column: "order_source_web",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_currency_id",
                table: "customer_order_item",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_CustomerOrderId",
                table: "customer_order_item",
                column: "CustomerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_item_type_id",
                table: "customer_order_item",
                column: "item_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_order_item_create_user",
                table: "customer_order_item",
                column: "order_item_create_user");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_order_item_delete_user",
                table: "customer_order_item",
                column: "order_item_delete_user");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_order_item_update_user",
                table: "customer_order_item",
                column: "order_item_update_user");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_routing_type_id",
                table: "customer_order_item",
                column: "routing_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_unit_of_measure",
                table: "customer_order_item",
                column: "unit_of_measure");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_unit_of_measure_base",
                table: "customer_order_item",
                column: "unit_of_measure_base");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_vat_id",
                table: "customer_order_item",
                column: "vat_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_warehouse_card_id",
                table: "customer_order_item",
                column: "warehouse_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_sum_currency_id",
                table: "customer_order_sum",
                column: "currency_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_sum_customer_order_id",
                table: "customer_order_sum",
                column: "customer_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_sum_vat_id",
                table: "customer_order_sum",
                column: "vat_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_item_type_item_type_id",
                table: "order_item_type",
                column: "item_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_card_WarehouseCardCreateUserNavigationSystemUserId",
                table: "warehouse_card",
                column: "WarehouseCardCreateUserNavigationSystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_card_WarehouseCardDeleteUserNavigationSystemUserId",
                table: "warehouse_card",
                column: "WarehouseCardDeleteUserNavigationSystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_card_WarehouseCardUpdateUserNavigationSystemUserId",
                table: "warehouse_card",
                column: "WarehouseCardUpdateUserNavigationSystemUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_order_item");

            migrationBuilder.DropTable(
                name: "customer_order_sum");

            migrationBuilder.DropTable(
                name: "order_item_type");

            migrationBuilder.DropTable(
                name: "routing_type");

            migrationBuilder.DropTable(
                name: "unit_of_measure");

            migrationBuilder.DropTable(
                name: "warehouse_card");

            migrationBuilder.DropTable(
                name: "customer_order");

            migrationBuilder.DropTable(
                name: "vat");

            migrationBuilder.DropTable(
                name: "item_type");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "customer_address");

            migrationBuilder.DropTable(
                name: "customer_order_delivery_status");

            migrationBuilder.DropTable(
                name: "customer_order_delivery_type");

            migrationBuilder.DropTable(
                name: "customer_order_payment_status");

            migrationBuilder.DropTable(
                name: "customer_order_payment_type");

            migrationBuilder.DropTable(
                name: "customer_order_status");

            migrationBuilder.DropTable(
                name: "eshop");

            migrationBuilder.DropTable(
                name: "system_user");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "customer_address_type");

            migrationBuilder.DropTable(
                name: "validate_vat_number_status");
        }
    }
}
