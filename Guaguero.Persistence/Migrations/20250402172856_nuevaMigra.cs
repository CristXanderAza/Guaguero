using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Guaguero.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class nuevaMigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_WayPoints_NearestWayPointWayPointID",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_NearestWayPointWayPointID",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "NearestWayPointWayPointID",
                table: "Travels",
                newName: "SeetsOcupied");

            migrationBuilder.AlterColumn<decimal>(
                name: "Actual_Lng",
                table: "Travels",
                type: "decimal(9,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Actual_Lat",
                table: "Travels",
                type: "decimal(9,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AddColumn<int>(
                name: "BusCapacity",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NearestWayPointID",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Origin_Lng",
                table: "Routes",
                type: "decimal(9,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Origin_Lat",
                table: "Routes",
                type: "decimal(9,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Destination_Lng",
                table: "Routes",
                type: "decimal(9,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Destination_Lat",
                table: "Routes",
                type: "decimal(9,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteID", "CreatedAt", "CreatedBy", "Description", "Destination", "Distance", "Duration", "GeoJSON", "IsDeleted", "Name", "Origin", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Ruta Romana Santo Domingo", "Santo Domingo", 0m, 0m, "{\r\n                  \"type\": \"FeatureCollection\",\r\n                  \"features\": [\r\n                    {\r\n                      \"type\": \"Feature\",\r\n                      \"geometry\": {\r\n                        \"coordinates\": [\r\n                          [\r\n                            -68.995771,\r\n                            18.432777\r\n                          ],\r\n                          [\r\n                            -69.012551,\r\n                            18.438519\r\n                          ],\r\n                          [\r\n                            -69.019976,\r\n                            18.441164\r\n                          ],\r\n                          [\r\n                            -69.022379,\r\n                            18.442283\r\n                          ],\r\n                          [\r\n                            -69.026102,\r\n                            18.443219\r\n                          ],\r\n                          [\r\n                            -69.029557,\r\n                            18.443087\r\n                          ],\r\n                          [\r\n                            -69.043643,\r\n                            18.44387\r\n                          ],\r\n                          [\r\n                            -69.050821,\r\n                            18.442659\r\n                          ],\r\n                          [\r\n                            -69.054179,\r\n                            18.442103\r\n                          ],\r\n                          [\r\n                            -69.062719,\r\n                            18.442592\r\n                          ],\r\n                          [\r\n                            -69.065509,\r\n                            18.443385\r\n                          ],\r\n                          [\r\n                            -69.073706,\r\n                            18.446376\r\n                          ],\r\n                          [\r\n                            -69.077697,\r\n                            18.44662\r\n                          ],\r\n                          [\r\n                            -69.085894,\r\n                            18.446213\r\n                          ],\r\n                          [\r\n                            -69.092524,\r\n                            18.444769\r\n                          ],\r\n                          [\r\n                            -69.136791,\r\n                            18.451939\r\n                          ],\r\n                          [\r\n                            -69.153271,\r\n                            18.447071\r\n                          ],\r\n                          [\r\n                            -69.188204,\r\n                            18.453581\r\n                          ],\r\n                          [\r\n                            -69.205456,\r\n                            18.460335\r\n                          ],\r\n                          [\r\n                            -69.212365,\r\n                            18.459794\r\n                          ],\r\n                          [\r\n                            -69.22996,\r\n                            18.457637\r\n                          ],\r\n                          [\r\n                            -69.2488,\r\n                            18.457027\r\n                          ],\r\n                          [\r\n                            -69.250731,\r\n                            18.457552\r\n                          ],\r\n                          [\r\n                            -69.252341,\r\n                            18.458671\r\n                          ],\r\n                          [\r\n                            -69.253113,\r\n                            18.459749\r\n                          ],\r\n                          [\r\n                            -69.253811,\r\n                            18.461476\r\n                          ],\r\n                          [\r\n                            -69.254395,\r\n                            18.463135\r\n                          ],\r\n                          [\r\n                            -69.255227,\r\n                            18.465653\r\n                          ],\r\n                          [\r\n                            -69.256074,\r\n                            18.468123\r\n                          ],\r\n                          [\r\n                            -69.257147,\r\n                            18.471372\r\n                          ],\r\n                          [\r\n                            -69.257796,\r\n                            18.472655\r\n                          ],\r\n                          [\r\n                            -69.258349,\r\n                            18.473728\r\n                          ],\r\n                          [\r\n                            -69.258928,\r\n                            18.47466\r\n                          ],\r\n                          [\r\n                            -69.259846,\r\n                            18.475977\r\n                          ],\r\n                          [\r\n                            -69.260755,\r\n                            18.477009\r\n                          ],\r\n                          [\r\n                            -69.262555,\r\n                            18.478679\r\n                          ],\r\n                          [\r\n                            -69.263864,\r\n                            18.479777\r\n                          ],\r\n                          [\r\n                            -69.265151,\r\n                            18.48057\r\n                          ],\r\n                          [\r\n                            -69.267125,\r\n                            18.481547\r\n                          ],\r\n                          [\r\n                            -69.269142,\r\n                            18.48234\r\n                          ],\r\n                          [\r\n                            -69.274045,\r\n                            18.483669\r\n                          ],\r\n                          [\r\n                            -69.279796,\r\n                            18.485237\r\n                          ],\r\n                          [\r\n                            -69.281711,\r\n                            18.486016\r\n                          ],\r\n                          [\r\n                            -69.28332,\r\n                            18.486855\r\n                          ],\r\n                          [\r\n                            -69.284672,\r\n                            18.487744\r\n                          ],\r\n                          [\r\n                            -69.286657,\r\n                            18.489306\r\n                          ],\r\n                          [\r\n                            -69.28928,\r\n                            18.491444\r\n                          ],\r\n                          [\r\n                            -69.291383,\r\n                            18.493158\r\n                          ],\r\n                          [\r\n                            -69.293354,\r\n                            18.495032\r\n                          ],\r\n                          [\r\n                            -69.295278,\r\n                            18.49738\r\n                          ],\r\n                          [\r\n                            -69.296265,\r\n                            18.498709\r\n                          ],\r\n                          [\r\n                            -69.297311,\r\n                            18.499736\r\n                          ],\r\n                          [\r\n                            -69.298448,\r\n                            18.500586\r\n                          ],\r\n                          [\r\n                            -69.300052,\r\n                            18.501374\r\n                          ],\r\n                          [\r\n                            -69.301377,\r\n                            18.501811\r\n                          ],\r\n                          [\r\n                            -69.303287,\r\n                            18.502055\r\n                          ],\r\n                          [\r\n                            -69.304588,\r\n                            18.502015\r\n                          ],\r\n                          [\r\n                            -69.309697,\r\n                            18.501313\r\n                          ],\r\n                          [\r\n                            -69.31172,\r\n                            18.501333\r\n                          ],\r\n                          [\r\n                            -69.314064,\r\n                            18.501618\r\n                          ],\r\n                          [\r\n                            -69.323655,\r\n                            18.502813\r\n                          ],\r\n                          [\r\n                            -69.328478,\r\n                            18.503363\r\n                          ],\r\n                          [\r\n                            -69.329867,\r\n                            18.503272\r\n                          ],\r\n                          [\r\n                            -69.331178,\r\n                            18.503052\r\n                          ],\r\n                          [\r\n                            -69.339539,\r\n                            18.499986\r\n                          ],\r\n                          [\r\n                            -69.341959,\r\n                            18.499039\r\n                          ],\r\n                          [\r\n                            -69.342769,\r\n                            18.498622\r\n                          ],\r\n                          [\r\n                            -69.343536,\r\n                            18.498007\r\n                          ],\r\n                          [\r\n                            -69.344383,\r\n                            18.497025\r\n                          ],\r\n                          [\r\n                            -69.345016,\r\n                            18.495703\r\n                          ],\r\n                          [\r\n                            -69.345199,\r\n                            18.494426\r\n                          ],\r\n                          [\r\n                            -69.345161,\r\n                            18.493368\r\n                          ],\r\n                          [\r\n                            -69.34478,\r\n                            18.492091\r\n                          ],\r\n                          [\r\n                            -69.343868,\r\n                            18.489598\r\n                          ],\r\n                          [\r\n                            -69.339888,\r\n                            18.479326\r\n                          ],\r\n                          [\r\n                            -69.339105,\r\n                            18.477277\r\n                          ],\r\n                          [\r\n                            -69.337496,\r\n                            18.473064\r\n                          ],\r\n                          [\r\n                            -69.335017,\r\n                            18.466597\r\n                          ],\r\n                          [\r\n                            -69.334454,\r\n                            18.465098\r\n                          ],\r\n                          [\r\n                            -69.333483,\r\n                            18.462688\r\n                          ],\r\n                          [\r\n                            -69.333032,\r\n                            18.461019\r\n                          ],\r\n                          [\r\n                            -69.333054,\r\n                            18.460057\r\n                          ],\r\n                          [\r\n                            -69.333011,\r\n                            18.456643\r\n                          ],\r\n                          [\r\n                            -69.333032,\r\n                            18.455853\r\n                          ],\r\n                          [\r\n                            -69.333263,\r\n                            18.454953\r\n                          ],\r\n                          [\r\n                            -69.333703,\r\n                            18.454037\r\n                          ],\r\n                          [\r\n                            -69.334438,\r\n                            18.453208\r\n                          ],\r\n                          [\r\n                            -69.335366,\r\n                            18.452444\r\n                          ],\r\n                          [\r\n                            -69.335969,\r\n                            18.452113\r\n                          ],\r\n                          [\r\n                            -69.341079,\r\n                            18.449184\r\n                          ],\r\n                          [\r\n                            -69.34256,\r\n                            18.448278\r\n                          ],\r\n                          [\r\n                            -69.343413,\r\n                            18.447529\r\n                          ],\r\n                          [\r\n                            -69.344067,\r\n                            18.446752\r\n                          ],\r\n                          [\r\n                            -69.344552,\r\n                            18.445999\r\n                          ],\r\n                          [\r\n                            -69.345542,\r\n                            18.444455\r\n                          ],\r\n                          [\r\n                            -69.347307,\r\n                            18.441723\r\n                          ],\r\n                          [\r\n                            -69.349823,\r\n                            18.437845\r\n                          ],\r\n                          [\r\n                            -69.350145,\r\n                            18.437457\r\n                          ],\r\n                          [\r\n                            -69.353551,\r\n                            18.434685\r\n                          ],\r\n                          [\r\n                            -69.358524,\r\n                            18.430721\r\n                          ],\r\n                          [\r\n                            -69.359382,\r\n                            18.430233\r\n                          ],\r\n                          [\r\n                            -69.360327,\r\n                            18.429857\r\n                          ],\r\n                          [\r\n                            -69.361367,\r\n                            18.429704\r\n                          ],\r\n                          [\r\n                            -69.36244,\r\n                            18.429826\r\n                          ],\r\n                          [\r\n                            -69.363502,\r\n                            18.430121\r\n                          ],\r\n                          [\r\n                            -69.364704,\r\n                            18.430671\r\n                          ],\r\n                          [\r\n                            -69.365653,\r\n                            18.431091\r\n                          ],\r\n                          [\r\n                            -69.366146,\r\n                            18.431262\r\n                          ],\r\n                          [\r\n                            -69.367633,\r\n                            18.431482\r\n                          ],\r\n                          [\r\n                            -69.368475,\r\n                            18.43149\r\n                          ],\r\n                          [\r\n                            -69.372053,\r\n                            18.431597\r\n                          ],\r\n                          [\r\n                            -69.372901,\r\n                            18.431699\r\n                          ],\r\n                          [\r\n                            -69.374639,\r\n                            18.432523\r\n                          ],\r\n                          [\r\n                            -69.377407,\r\n                            18.433998\r\n                          ],\r\n                          [\r\n                            -69.380711,\r\n                            18.435768\r\n                          ],\r\n                          [\r\n                            -69.382685,\r\n                            18.436867\r\n                          ],\r\n                          [\r\n                            -69.389589,\r\n                            18.440546\r\n                          ],\r\n                          [\r\n                            -69.393457,\r\n                            18.44264\r\n                          ],\r\n                          [\r\n                            -69.3957,\r\n                            18.443688\r\n                          ],\r\n                          [\r\n                            -69.396665,\r\n                            18.443952\r\n                          ],\r\n                          [\r\n                            -69.398596,\r\n                            18.444247\r\n                          ],\r\n                          [\r\n                            -69.401472,\r\n                            18.444573\r\n                          ],\r\n                          [\r\n                            -69.406396,\r\n                            18.445153\r\n                          ],\r\n                          [\r\n                            -69.411235,\r\n                            18.445743\r\n                          ],\r\n                          [\r\n                            -69.413477,\r\n                            18.446018\r\n                          ],\r\n                          [\r\n                            -69.418429,\r\n                            18.446582\r\n                          ],\r\n                          [\r\n                            -69.419711,\r\n                            18.446567\r\n                          ],\r\n                          [\r\n                            -69.420977,\r\n                            18.446261\r\n                          ],\r\n                          [\r\n                            -69.42184,\r\n                            18.44591\r\n                          ],\r\n                          [\r\n                            -69.426266,\r\n                            18.443769\r\n                          ],\r\n                          [\r\n                            -69.428294,\r\n                            18.442793\r\n                          ],\r\n                          [\r\n                            -69.440911,\r\n                            18.436819\r\n                          ],\r\n                          [\r\n                            -69.443786,\r\n                            18.436105\r\n                          ],\r\n                          [\r\n                            -69.450631,\r\n                            18.43465\r\n                          ],\r\n                          [\r\n                            -69.46607,\r\n                            18.427149\r\n                          ],\r\n                          [\r\n                            -69.469428,\r\n                            18.425447\r\n                          ],\r\n                          [\r\n                            -69.482238,\r\n                            18.415433\r\n                          ],\r\n                          [\r\n                            -69.484309,\r\n                            18.413767\r\n                          ],\r\n                          [\r\n                            -69.485709,\r\n                            18.412815\r\n                          ],\r\n                          [\r\n                            -69.486573,\r\n                            18.412367\r\n                          ],\r\n                          [\r\n                            -69.488375,\r\n                            18.411777\r\n                          ],\r\n                          [\r\n                            -69.489963,\r\n                            18.41139\r\n                          ],\r\n                          [\r\n                            -69.490827,\r\n                            18.411195\r\n                          ],\r\n                          [\r\n                            -69.491562,\r\n                            18.411119\r\n                          ],\r\n                          [\r\n                            -69.501024,\r\n                            18.409323\r\n                          ],\r\n                          [\r\n                            -69.51185,\r\n                            18.40512\r\n                          ],\r\n                          [\r\n                            -69.51266,\r\n                            18.404864\r\n                          ],\r\n                          [\r\n                            -69.515964,\r\n                            18.404721\r\n                          ],\r\n                          [\r\n                            -69.521828,\r\n                            18.404676\r\n                          ],\r\n                          [\r\n                            -69.526184,\r\n                            18.404795\r\n                          ],\r\n                          [\r\n                            -69.532245,\r\n                            18.405863\r\n                          ],\r\n                          [\r\n                            -69.541998,\r\n                            18.408215\r\n                          ],\r\n                          [\r\n                            -69.544659,\r\n                            18.409071\r\n                          ],\r\n                          [\r\n                            -69.546247,\r\n                            18.409844\r\n                          ],\r\n                          [\r\n                            -69.551139,\r\n                            18.41366\r\n                          ],\r\n                          [\r\n                            -69.55461,\r\n                            18.416194\r\n                          ],\r\n                          [\r\n                            -69.555897,\r\n                            18.417344\r\n                          ],\r\n                          [\r\n                            -69.561412,\r\n                            18.423253\r\n                          ],\r\n                          [\r\n                            -69.567136,\r\n                            18.430088\r\n                          ],\r\n                          [\r\n                            -69.572307,\r\n                            18.436299\r\n                          ],\r\n                          [\r\n                            -69.573541,\r\n                            18.437336\r\n                          ],\r\n                          [\r\n                            -69.57471,\r\n                            18.437784\r\n                          ],\r\n                          [\r\n                            -69.576663,\r\n                            18.438038\r\n                          ],\r\n                          [\r\n                            -69.578004,\r\n                            18.438506\r\n                          ],\r\n                          [\r\n                            -69.580032,\r\n                            18.440208\r\n                          ],\r\n                          [\r\n                            -69.582167,\r\n                            18.442273\r\n                          ],\r\n                          [\r\n                            -69.583004,\r\n                            18.442832\r\n                          ],\r\n                          [\r\n                            -69.584935,\r\n                            18.443656\r\n                          ],\r\n                          [\r\n                            -69.585836,\r\n                            18.444032\r\n                          ],\r\n                          [\r\n                            -69.586962,\r\n                            18.444533\r\n                          ],\r\n                          [\r\n                            -69.589258,\r\n                            18.44608\r\n                          ],\r\n                          [\r\n                            -69.591683,\r\n                            18.44788\r\n                          ],\r\n                          [\r\n                            -69.598764,\r\n                            18.452989\r\n                          ],\r\n                          [\r\n                            -69.599987,\r\n                            18.45361\r\n                          ],\r\n                          [\r\n                            -69.601302,\r\n                            18.454139\r\n                          ],\r\n                          [\r\n                            -69.603657,\r\n                            18.454581\r\n                          ],\r\n                          [\r\n                            -69.60709,\r\n                            18.454755\r\n                          ],\r\n                          [\r\n                            -69.60879,\r\n                            18.454831\r\n                          ],\r\n                          [\r\n                            -69.617486,\r\n                            18.455218\r\n                          ],\r\n                          [\r\n                            -69.619176,\r\n                            18.455055\r\n                          ],\r\n                          [\r\n                            -69.621381,\r\n                            18.454586\r\n                          ],\r\n                          [\r\n                            -69.624696,\r\n                            18.45302\r\n                          ],\r\n                          [\r\n                            -69.632635,\r\n                            18.449021\r\n                          ],\r\n                          [\r\n                            -69.635253,\r\n                            18.447984\r\n                          ],\r\n                          [\r\n                            -69.637184,\r\n                            18.44775\r\n                          ],\r\n                          [\r\n                            -69.64139,\r\n                            18.448024\r\n                          ],\r\n                          [\r\n                            -69.662193,\r\n                            18.4495\r\n                          ],\r\n                          [\r\n                            -69.672461,\r\n                            18.450141\r\n                          ],\r\n                          [\r\n                            -69.67525,\r\n                            18.450284\r\n                          ],\r\n                          [\r\n                            -69.683189,\r\n                            18.450863\r\n                          ],\r\n                          [\r\n                            -69.686215,\r\n                            18.451147\r\n                          ],\r\n                          [\r\n                            -69.688345,\r\n                            18.451752\r\n                          ],\r\n                          [\r\n                            -69.690485,\r\n                            18.452749\r\n                          ],\r\n                          [\r\n                            -69.692309,\r\n                            18.453461\r\n                          ],\r\n                          [\r\n                            -69.694648,\r\n                            18.454193\r\n                          ],\r\n                          [\r\n                            -69.695463,\r\n                            18.454375\r\n                          ],\r\n                          [\r\n                            -69.698583,\r\n                            18.455217\r\n                          ],\r\n                          [\r\n                            -69.701648,\r\n                            18.455447\r\n                          ],\r\n                          [\r\n                            -69.703242,\r\n                            18.455787\r\n                          ],\r\n                          [\r\n                            -69.705237,\r\n                            18.456199\r\n                          ],\r\n                          [\r\n                            -69.706353,\r\n                            18.456189\r\n                          ],\r\n                          [\r\n                            -69.708279,\r\n                            18.456037\r\n                          ],\r\n                          [\r\n                            -69.709759,\r\n                            18.455915\r\n                          ],\r\n                          [\r\n                            -69.710521,\r\n                            18.455981\r\n                          ],\r\n                          [\r\n                            -69.714593,\r\n                            18.456471\r\n                          ],\r\n                          [\r\n                            -69.717704,\r\n                            18.457549\r\n                          ],\r\n                          [\r\n                            -69.72073,\r\n                            18.458444\r\n                          ],\r\n                          [\r\n                            -69.722328,\r\n                            18.4588\r\n                          ],\r\n                          [\r\n                            -69.727703,\r\n                            18.460328\r\n                          ],\r\n                          [\r\n                            -69.734784,\r\n                            18.461895\r\n                          ],\r\n                          [\r\n                            -69.737767,\r\n                            18.462831\r\n                          ],\r\n                          [\r\n                            -69.744784,\r\n                            18.463669\r\n                          ],\r\n                          [\r\n                            -69.7501,\r\n                            18.463741\r\n                          ],\r\n                          [\r\n                            -69.752047,\r\n                            18.463842\r\n                          ],\r\n                          [\r\n                            -69.756832,\r\n                            18.464269\r\n                          ],\r\n                          [\r\n                            -69.762368,\r\n                            18.464432\r\n                          ],\r\n                          [\r\n                            -69.766059,\r\n                            18.46433\r\n                          ],\r\n                          [\r\n                            -69.768634,\r\n                            18.464575\r\n                          ],\r\n                          [\r\n                            -69.771273,\r\n                            18.464918\r\n                          ],\r\n                          [\r\n                            -69.774792,\r\n                            18.465254\r\n                          ],\r\n                          [\r\n                            -69.777839,\r\n                            18.465364\r\n                          ],\r\n                          [\r\n                            -69.779518,\r\n                            18.465537\r\n                          ],\r\n                          [\r\n                            -69.781321,\r\n                            18.465812\r\n                          ],\r\n                          [\r\n                            -69.783466,\r\n                            18.466112\r\n                          ],\r\n                          [\r\n                            -69.784319,\r\n                            18.466173\r\n                          ],\r\n                          [\r\n                            -69.786629,\r\n                            18.466223\r\n                          ],\r\n                          [\r\n                            -69.787632,\r\n                            18.466226\r\n                          ],\r\n                          [\r\n                            -69.788174,\r\n                            18.466236\r\n                          ],\r\n                          [\r\n                            -69.790451,\r\n                            18.466269\r\n                          ],\r\n                          [\r\n                            -69.793954,\r\n                            18.466332\r\n                          ],\r\n                          [\r\n                            -69.795928,\r\n                            18.466088\r\n                          ],\r\n                          [\r\n                            -69.798546,\r\n                            18.465478\r\n                          ],\r\n                          [\r\n                            -69.800735,\r\n                            18.46501\r\n                          ],\r\n                          [\r\n                            -69.801872,\r\n                            18.464861\r\n                          ],\r\n                          [\r\n                            -69.804366,\r\n                            18.464876\r\n                          ],\r\n                          [\r\n                            -69.806249,\r\n                            18.464917\r\n                          ],\r\n                          [\r\n                            -69.808341,\r\n                            18.464576\r\n                          ],\r\n                          [\r\n                            -69.809283,\r\n                            18.464488\r\n                          ],\r\n                          [\r\n                            -69.811281,\r\n                            18.464612\r\n                          ],\r\n                          [\r\n                            -69.814864,\r\n                            18.464918\r\n                          ],\r\n                          [\r\n                            -69.817911,\r\n                            18.465111\r\n                          ],\r\n                          [\r\n                            -69.819499,\r\n                            18.465335\r\n                          ],\r\n                          [\r\n                            -69.821634,\r\n                            18.465847\r\n                          ],\r\n                          [\r\n                            -69.822745,\r\n                            18.466178\r\n                          ],\r\n                          [\r\n                            -69.824692,\r\n                            18.466841\r\n                          ],\r\n                          [\r\n                            -69.82672,\r\n                            18.467634\r\n                          ],\r\n                          [\r\n                            -69.828297,\r\n                            18.468478\r\n                          ],\r\n                          [\r\n                            -69.829359,\r\n                            18.469251\r\n                          ],\r\n                          [\r\n                            -69.831773,\r\n                            18.471633\r\n                          ],\r\n                          [\r\n                            -69.835249,\r\n                            18.476355\r\n                          ],\r\n                          [\r\n                            -69.837234,\r\n                            18.479093\r\n                          ],\r\n                          [\r\n                            -69.838629,\r\n                            18.480903\r\n                          ],\r\n                          [\r\n                            -69.839809,\r\n                            18.481483\r\n                          ],\r\n                          [\r\n                            -69.841574,\r\n                            18.481864\r\n                          ],\r\n                          [\r\n                            -69.843628,\r\n                            18.481976\r\n                          ],\r\n                          [\r\n                            -69.844776,\r\n                            18.482047\r\n                          ],\r\n                          [\r\n                            -69.84615,\r\n                            18.48217\r\n                          ],\r\n                          [\r\n                            -69.846901,\r\n                            18.482292\r\n                          ],\r\n                          [\r\n                            -69.847367,\r\n                            18.482521\r\n                          ],\r\n                          [\r\n                            -69.847915,\r\n                            18.483258\r\n                          ],\r\n                          [\r\n                            -69.848269,\r\n                            18.484199\r\n                          ],\r\n                          [\r\n                            -69.848263,\r\n                            18.484362\r\n                          ],\r\n                          [\r\n                            -69.848092,\r\n                            18.484555\r\n                          ],\r\n                          [\r\n                            -69.847534,\r\n                            18.484677\r\n                          ],\r\n                          [\r\n                            -69.846686,\r\n                            18.484891\r\n                          ],\r\n                          [\r\n                            -69.845967,\r\n                            18.484931\r\n                          ],\r\n                          [\r\n                            -69.845586,\r\n                            18.484891\r\n                          ],\r\n                          [\r\n                            -69.84483,\r\n                            18.484865\r\n                          ],\r\n                          [\r\n                            -69.844294,\r\n                            18.484774\r\n                          ],\r\n                          [\r\n                            -69.843827,\r\n                            18.484514\r\n                          ],\r\n                          [\r\n                            -69.843081,\r\n                            18.484174\r\n                          ]\r\n                        ],\r\n                        \"type\": \"LineString\"\r\n                      },\r\n                      \"properties\": {\r\n                        \"name\": \"Ruta La Romana-Sto.Dom\"\r\n                      },\r\n                      \"id\": \"A1NDQ\"\r\n                    }\r\n                  ]\r\n                }", false, "Ruta La Romana-Sto.Dom", "La Romana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Sindicatos",
                columns: new[] { "SindicatoID", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Empresa de Guagua", false, "Sichoem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Credential_Email", "Credential_PasswordHash", "CreatedAt", "CreatedBy", "DiscountID", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAt", "UpdatedBy", "UserType" },
                values: new object[] { new Guid("a3f47c2b-1b3d-4e19-8e2a-3d9f7c5a1d5e"), "example@gmail.com", "a0f3285b07c26c0dcd2191447f391170d06035e8d57e31a048ba87074f3a9a15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Cristopher", false, "Aza", "809-425-1911", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Customer" });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusID", "Capacidad", "Color", "CreatedAt", "CreatedBy", "Estado", "IsActive", "IsDeleted", "Marca", "Modelo", "Placa", "SindicatoID", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, 50, "Azul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "SD", true, false, "dfasf", "dfsa", "23131", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Credential_Email", "Credential_PasswordHash", "CreatedAt", "CreatedBy", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "Salary", "SindicatoID", "UpdatedAt", "UpdatedBy", "UserType" },
                values: new object[] { new Guid("d5f1a8e7-4c6b-49f2-b7d9-65e3c7f9b2a1"), "juan@gmail.com", "a0f3285b07c26c0dcd2191447f391170d06035e8d57e31a048ba87074f3a9a15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Juan", false, "829-345-6788", "829-345-6788", 20000m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Employee" });

            migrationBuilder.InsertData(
                table: "WayPoints",
                columns: new[] { "WayPointID", "RouteID", "StepIndex", "WayPoint_Lat", "WayPoint_Lng" },
                values: new object[,]
                {
                    { 1, 1, 1, -69.543151m, -69.543151m },
                    { 2, 1, 2, 18.453213m, -69.186487m },
                    { 3, 1, 3, 18.449958m, -69.668553m },
                    { 4, 1, 4, 18.450846m, -69.685045m }
                });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "TravelID", "ActualStep", "Arrival", "BusCapacity", "BusID", "CreatedAt", "CreatedBy", "Departure", "EmpleoyeeID", "Exits", "InformalQuotas", "IsDeleted", "NearestWayPointID", "PricePerSeat", "RouteID", "SeetsOcupied", "SindicatoID", "Status", "StepState", "TotalSteps", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("f7c2a3d5-1b4e-4d19-8e2f-9f6a3c5b7d1e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5f1a8e7-4c6b-49f2-b7d9-65e3c7f9b2a1"), 0, 1, false, 1, 275m, 1, 0, 1, 0, 0, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_NearestWayPointID",
                table: "Travels",
                column: "NearestWayPointID");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_WayPoints_NearestWayPointID",
                table: "Travels",
                column: "NearestWayPointID",
                principalTable: "WayPoints",
                principalColumn: "WayPointID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_WayPoints_NearestWayPointID",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_NearestWayPointID",
                table: "Travels");

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "TravelID",
                keyValue: new Guid("f7c2a3d5-1b4e-4d19-8e2f-9f6a3c5b7d1e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("a3f47c2b-1b3d-4e19-8e2a-3d9f7c5a1d5e"));

            migrationBuilder.DeleteData(
                table: "WayPoints",
                keyColumn: "WayPointID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WayPoints",
                keyColumn: "WayPointID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WayPoints",
                keyColumn: "WayPointID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("d5f1a8e7-4c6b-49f2-b7d9-65e3c7f9b2a1"));

            migrationBuilder.DeleteData(
                table: "WayPoints",
                keyColumn: "WayPointID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "RouteID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sindicatos",
                keyColumn: "SindicatoID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "BusCapacity",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "NearestWayPointID",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "SeetsOcupied",
                table: "Travels",
                newName: "NearestWayPointWayPointID");

            migrationBuilder.AlterColumn<decimal>(
                name: "Actual_Lng",
                table: "Travels",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Actual_Lat",
                table: "Travels",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Origin_Lng",
                table: "Routes",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Origin_Lat",
                table: "Routes",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Destination_Lng",
                table: "Routes",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Destination_Lat",
                table: "Routes",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_NearestWayPointWayPointID",
                table: "Travels",
                column: "NearestWayPointWayPointID");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_WayPoints_NearestWayPointWayPointID",
                table: "Travels",
                column: "NearestWayPointWayPointID",
                principalTable: "WayPoints",
                principalColumn: "WayPointID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
