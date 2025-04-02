using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guaguero.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountID);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Origin_Lat = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Origin_Lng = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Destination_Lat = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Destination_Lng = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    GeoJSON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "Sindicatos",
                columns: table => new
                {
                    SindicatoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sindicatos", x => x.SindicatoID);
                });

            migrationBuilder.CreateTable(
                name: "WayPoints",
                columns: table => new
                {
                    WayPointID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WayPoint_Lat = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    WayPoint_Lng = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    RouteID = table.Column<int>(type: "int", nullable: false),
                    StepIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WayPoints", x => x.WayPointID);
                    table.ForeignKey(
                        name: "FK_WayPoints_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID");
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SindicatoID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusID);
                    table.ForeignKey(
                        name: "FK_Buses_Sindicatos_SindicatoID",
                        column: x => x.SindicatoID,
                        principalTable: "Sindicatos",
                        principalColumn: "SindicatoID");
                });

            migrationBuilder.CreateTable(
                name: "SindicatoRoutes",
                columns: table => new
                {
                    RoutesRouteID = table.Column<int>(type: "int", nullable: false),
                    SindicatosSindicatoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SindicatoRoutes", x => new { x.RoutesRouteID, x.SindicatosSindicatoID });
                    table.ForeignKey(
                        name: "FK_SindicatoRoutes_Routes_RoutesRouteID",
                        column: x => x.RoutesRouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SindicatoRoutes_Sindicatos_SindicatosSindicatoID",
                        column: x => x.SindicatosSindicatoID,
                        principalTable: "Sindicatos",
                        principalColumn: "SindicatoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Credential_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credential_PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DiscountID = table.Column<int>(type: "int", nullable: true),
                    SindicatoID = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "DiscountID");
                    table.ForeignKey(
                        name: "FK_Users_Sindicatos_SindicatoID",
                        column: x => x.SindicatoID,
                        principalTable: "Sindicatos",
                        principalColumn: "SindicatoID");
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    CreditPerUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.CreditPerUserID);
                    table.ForeignKey(
                        name: "FK_Credits_Users_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Credits_Users_CustomerUserID",
                        column: x => x.CustomerUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountSolicituds",
                columns: table => new
                {
                    SolicitudID = table.Column<int>(type: "int", nullable: false),
                    DiscountID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountSolicituds", x => x.SolicitudID);
                    table.ForeignKey(
                        name: "FK_DiscountSolicituds_Discounts_SolicitudID",
                        column: x => x.SolicitudID,
                        principalTable: "Discounts",
                        principalColumn: "DiscountID");
                    table.ForeignKey(
                        name: "FK_DiscountSolicituds_Users_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    TravelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteID = table.Column<int>(type: "int", nullable: false),
                    BusID = table.Column<int>(type: "int", nullable: false),
                    EmpleoyeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SindicatoID = table.Column<int>(type: "int", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InformalQuotas = table.Column<int>(type: "int", nullable: false),
                    Exits = table.Column<int>(type: "int", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actual_Lat = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Actual_Lng = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StepState = table.Column<int>(type: "int", nullable: false),
                    NearestWayPointWayPointID = table.Column<int>(type: "int", nullable: false),
                    ActualStep = table.Column<int>(type: "int", nullable: false),
                    TotalSteps = table.Column<int>(type: "int", nullable: false),
                    PricePerSeat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.TravelID);
                    table.ForeignKey(
                        name: "FK_Travels_Buses_BusID",
                        column: x => x.BusID,
                        principalTable: "Buses",
                        principalColumn: "BusID");
                    table.ForeignKey(
                        name: "FK_Travels_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID");
                    table.ForeignKey(
                        name: "FK_Travels_Users_EmpleoyeeID",
                        column: x => x.EmpleoyeeID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Travels_WayPoints_NearestWayPointWayPointID",
                        column: x => x.NearestWayPointWayPointID,
                        principalTable: "WayPoints",
                        principalColumn: "WayPointID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reloads",
                columns: table => new
                {
                    ReloadID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreditID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditPerUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reloads", x => x.ReloadID);
                    table.ForeignKey(
                        name: "FK_Reloads_Credits_CreditID",
                        column: x => x.CreditID,
                        principalTable: "Credits",
                        principalColumn: "CreditPerUserID");
                    table.ForeignKey(
                        name: "FK_Reloads_Credits_CreditPerUserID",
                        column: x => x.CreditPerUserID,
                        principalTable: "Credits",
                        principalColumn: "CreditPerUserID");
                });

            migrationBuilder.CreateTable(
                name: "Quotas",
                columns: table => new
                {
                    QuotaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EntryStep = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntryPointWayPointID = table.Column<int>(type: "int", nullable: true),
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotas", x => x.QuotaID);
                    table.ForeignKey(
                        name: "FK_Quotas_Travels_TravelID",
                        column: x => x.TravelID,
                        principalTable: "Travels",
                        principalColumn: "TravelID");
                    table.ForeignKey(
                        name: "FK_Quotas_Users_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Quotas_WayPoints_EntryPointWayPointID",
                        column: x => x.EntryPointWayPointID,
                        principalTable: "WayPoints",
                        principalColumn: "WayPointID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    QuotaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CreditPerUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Devolution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Credits_CreditPerUserID",
                        column: x => x.CreditPerUserID,
                        principalTable: "Credits",
                        principalColumn: "CreditPerUserID");
                    table.ForeignKey(
                        name: "FK_Payments_Quotas_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Quotas",
                        principalColumn: "QuotaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_SindicatoID",
                table: "Buses",
                column: "SindicatoID");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CustomerID",
                table: "Credits",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CustomerUserID",
                table: "Credits",
                column: "CustomerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountSolicituds_CustomerID",
                table: "DiscountSolicituds",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreditPerUserID",
                table: "Payments",
                column: "CreditPerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotas_CustomerID",
                table: "Quotas",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotas_EntryPointWayPointID",
                table: "Quotas",
                column: "EntryPointWayPointID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotas_EntryStep",
                table: "Quotas",
                column: "EntryStep");

            migrationBuilder.CreateIndex(
                name: "IX_Quotas_TravelID",
                table: "Quotas",
                column: "TravelID");

            migrationBuilder.CreateIndex(
                name: "IX_Reloads_CreditID",
                table: "Reloads",
                column: "CreditID");

            migrationBuilder.CreateIndex(
                name: "IX_Reloads_CreditPerUserID",
                table: "Reloads",
                column: "CreditPerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SindicatoRoutes_SindicatosSindicatoID",
                table: "SindicatoRoutes",
                column: "SindicatosSindicatoID");

            migrationBuilder.CreateIndex(
                name: "IX_Sindicatos_Name",
                table: "Sindicatos",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_BusID",
                table: "Travels",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_EmpleoyeeID",
                table: "Travels",
                column: "EmpleoyeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_NearestWayPointWayPointID",
                table: "Travels",
                column: "NearestWayPointWayPointID");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_RouteID",
                table: "Travels",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DiscountID",
                table: "Users",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SindicatoID",
                table: "Users",
                column: "SindicatoID");

            migrationBuilder.CreateIndex(
                name: "IX_WayPoints_RouteID",
                table: "WayPoints",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_WayPoints_StepIndex",
                table: "WayPoints",
                column: "StepIndex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountSolicituds");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reloads");

            migrationBuilder.DropTable(
                name: "SindicatoRoutes");

            migrationBuilder.DropTable(
                name: "Quotas");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WayPoints");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Sindicatos");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
