namespace _2013215462_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministradorEquipo",
                c => new
                    {
                        AdministradorEquipoID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdministradorEquipoID);
            
            CreateTable(
                "dbo.EquipoCelular",
                c => new
                    {
                        EquipoCelularID = c.Int(nullable: false, identity: true),
                        AdministradorEquipoID = c.Int(nullable: false),
                        EvaluacionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipoCelularID)
                .ForeignKey("dbo.AdministradorEquipo", t => t.AdministradorEquipoID, cascadeDelete: true)
                .Index(t => t.AdministradorEquipoID);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        EvaluacionID = c.Int(nullable: false),
                        VentaID = c.Int(nullable: false),
                        TrabajadorID = c.Int(nullable: false),
                        CentroAtencionID = c.Int(nullable: false),
                        Cliente_ClienteID = c.Int(nullable: false),
                        EquipoCelular_EquipoCelularID = c.Int(nullable: false),
                        EstadoEvaluacion_EstadoEvaluacionID = c.Int(nullable: false),
                        LineaTelefonica_LineaTelefonicaID = c.Int(nullable: false),
                        Plan_PlanID = c.Int(nullable: false),
                        TipoEvaluacion_TipoEvaluacionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluacionID)
                .ForeignKey("dbo.Venta", t => t.EvaluacionID)
                .ForeignKey("dbo.CentroAtencion", t => t.CentroAtencionID, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.EquipoCelular", t => t.EquipoCelular_EquipoCelularID, cascadeDelete: true)
                .ForeignKey("dbo.EstadoEvaluacion", t => t.EstadoEvaluacion_EstadoEvaluacionID, cascadeDelete: true)
                .ForeignKey("dbo.LineaTelefonica", t => t.LineaTelefonica_LineaTelefonicaID, cascadeDelete: true)
                .ForeignKey("dbo.Plan", t => t.Plan_PlanID, cascadeDelete: true)
                .ForeignKey("dbo.TipoEvaluacion", t => t.TipoEvaluacion_TipoEvaluacionID, cascadeDelete: true)
                .ForeignKey("dbo.Trabajor", t => t.TrabajadorID, cascadeDelete: true)
                .Index(t => t.EvaluacionID)
                .Index(t => t.TrabajadorID)
                .Index(t => t.CentroAtencionID)
                .Index(t => t.Cliente_ClienteID)
                .Index(t => t.EquipoCelular_EquipoCelularID)
                .Index(t => t.EstadoEvaluacion_EstadoEvaluacionID)
                .Index(t => t.LineaTelefonica_LineaTelefonicaID)
                .Index(t => t.Plan_PlanID)
                .Index(t => t.TipoEvaluacion_TipoEvaluacionID);
            
            CreateTable(
                "dbo.CentroAtencion",
                c => new
                    {
                        CentroAtencionID = c.Int(nullable: false, identity: true),
                        DireccionID = c.Int(nullable: false),
                        EvaluacionID = c.Int(nullable: false),
                        VentaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CentroAtencionID);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        DireccionID = c.Int(nullable: false),
                        CadenaUbigeo = c.String(),
                        CentroAtencionID = c.Int(nullable: false),
                        DistritoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionID)
                .ForeignKey("dbo.Distrito", t => t.DistritoID, cascadeDelete: true)
                .ForeignKey("dbo.CentroAtencion", t => t.DireccionID)
                .Index(t => t.DireccionID)
                .Index(t => t.DistritoID);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        DistritoID = c.Int(nullable: false, identity: true),
                        ProvinciaID = c.Int(nullable: false),
                        CadenaUbigeo = c.String(),
                    })
                .PrimaryKey(t => t.DistritoID)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaID, cascadeDelete: true)
                .Index(t => t.ProvinciaID);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        ProvinciaID = c.Int(nullable: false, identity: true),
                        CadenaUbigeo = c.String(),
                        DepartamentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinciaID)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoID, cascadeDelete: true)
                .Index(t => t.DepartamentoID);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoID = c.Int(nullable: false, identity: true),
                        ProvinciaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentoID);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        CentroAtencionID = c.Int(nullable: false),
                        Cliente_ClienteID = c.Int(nullable: false),
                        TipoPago_TipoPagoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaID)
                .ForeignKey("dbo.CentroAtencion", t => t.CentroAtencionID, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.TipoPago", t => t.TipoPago_TipoPagoID, cascadeDelete: true)
                .Index(t => t.CentroAtencionID)
                .Index(t => t.Cliente_ClienteID)
                .Index(t => t.TipoPago_TipoPagoID);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        EvaluacionID = c.Int(nullable: false),
                        VentaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Contrato",
                c => new
                    {
                        ContratoID = c.Int(nullable: false),
                        VentaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContratoID)
                .ForeignKey("dbo.Venta", t => t.ContratoID)
                .Index(t => t.ContratoID);
            
            CreateTable(
                "dbo.LineaTelefonica",
                c => new
                    {
                        LineaTelefonicaID = c.Int(nullable: false),
                        AdministradorLineaID = c.Int(nullable: false),
                        VentaID = c.Int(nullable: false),
                        EvaluacionID = c.Int(nullable: false),
                        TipoLinea_TipoLineaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineaTelefonicaID)
                .ForeignKey("dbo.AdministradorLinea", t => t.AdministradorLineaID, cascadeDelete: true)
                .ForeignKey("dbo.TipoLinea", t => t.TipoLinea_TipoLineaID, cascadeDelete: true)
                .ForeignKey("dbo.Venta", t => t.LineaTelefonicaID)
                .Index(t => t.LineaTelefonicaID)
                .Index(t => t.AdministradorLineaID)
                .Index(t => t.TipoLinea_TipoLineaID);
            
            CreateTable(
                "dbo.AdministradorLinea",
                c => new
                    {
                        AdministradorLineaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdministradorLineaID);
            
            CreateTable(
                "dbo.TipoLinea",
                c => new
                    {
                        TipoLineaID = c.Int(nullable: false, identity: true),
                        LineaTelefonicaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoLineaID);
            
            CreateTable(
                "dbo.TipoPago",
                c => new
                    {
                        TipoPagoID = c.Int(nullable: false, identity: true),
                        VentaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPagoID);
            
            CreateTable(
                "dbo.EstadoEvaluacion",
                c => new
                    {
                        EstadoEvaluacionID = c.Int(nullable: false, identity: true),
                        EvaluacionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoEvaluacionID);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanID = c.Int(nullable: false, identity: true),
                        EvaluacionID = c.Int(nullable: false),
                        TipoPlan_TipoPlanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanID)
                .ForeignKey("dbo.TipoPlan", t => t.TipoPlan_TipoPlanID, cascadeDelete: true)
                .Index(t => t.TipoPlan_TipoPlanID);
            
            CreateTable(
                "dbo.TipoPlan",
                c => new
                    {
                        TipoPlanID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TipoPlanID);
            
            CreateTable(
                "dbo.TipoEvaluacion",
                c => new
                    {
                        TipoEvaluacionID = c.Int(nullable: false, identity: true),
                        EvaluacionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoEvaluacionID);
            
            CreateTable(
                "dbo.Trabajor",
                c => new
                    {
                        TrabajadorID = c.Int(nullable: false, identity: true),
                        EvaluacionID = c.Int(nullable: false),
                        TipoTrabajador_TipoTrabajadorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrabajadorID)
                .ForeignKey("dbo.TipoTrabajador", t => t.TipoTrabajador_TipoTrabajadorID, cascadeDelete: true)
                .Index(t => t.TipoTrabajador_TipoTrabajadorID);
            
            CreateTable(
                "dbo.TipoTrabajador",
                c => new
                    {
                        TipoTrabajadorID = c.Int(nullable: false, identity: true),
                        TrabajadorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoTrabajadorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacion", "TrabajadorID", "dbo.Trabajor");
            DropForeignKey("dbo.Trabajor", "TipoTrabajador_TipoTrabajadorID", "dbo.TipoTrabajador");
            DropForeignKey("dbo.Evaluacion", "TipoEvaluacion_TipoEvaluacionID", "dbo.TipoEvaluacion");
            DropForeignKey("dbo.Evaluacion", "Plan_PlanID", "dbo.Plan");
            DropForeignKey("dbo.Plan", "TipoPlan_TipoPlanID", "dbo.TipoPlan");
            DropForeignKey("dbo.Evaluacion", "LineaTelefonica_LineaTelefonicaID", "dbo.LineaTelefonica");
            DropForeignKey("dbo.Evaluacion", "EstadoEvaluacion_EstadoEvaluacionID", "dbo.EstadoEvaluacion");
            DropForeignKey("dbo.Evaluacion", "EquipoCelular_EquipoCelularID", "dbo.EquipoCelular");
            DropForeignKey("dbo.Evaluacion", "Cliente_ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.Evaluacion", "CentroAtencionID", "dbo.CentroAtencion");
            DropForeignKey("dbo.Venta", "TipoPago_TipoPagoID", "dbo.TipoPago");
            DropForeignKey("dbo.LineaTelefonica", "LineaTelefonicaID", "dbo.Venta");
            DropForeignKey("dbo.LineaTelefonica", "TipoLinea_TipoLineaID", "dbo.TipoLinea");
            DropForeignKey("dbo.LineaTelefonica", "AdministradorLineaID", "dbo.AdministradorLinea");
            DropForeignKey("dbo.Evaluacion", "EvaluacionID", "dbo.Venta");
            DropForeignKey("dbo.Contrato", "ContratoID", "dbo.Venta");
            DropForeignKey("dbo.Venta", "Cliente_ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.Venta", "CentroAtencionID", "dbo.CentroAtencion");
            DropForeignKey("dbo.Direccion", "DireccionID", "dbo.CentroAtencion");
            DropForeignKey("dbo.Direccion", "DistritoID", "dbo.Distrito");
            DropForeignKey("dbo.Distrito", "ProvinciaID", "dbo.Provincia");
            DropForeignKey("dbo.Provincia", "DepartamentoID", "dbo.Departamento");
            DropForeignKey("dbo.EquipoCelular", "AdministradorEquipoID", "dbo.AdministradorEquipo");
            DropIndex("dbo.Trabajor", new[] { "TipoTrabajador_TipoTrabajadorID" });
            DropIndex("dbo.Plan", new[] { "TipoPlan_TipoPlanID" });
            DropIndex("dbo.LineaTelefonica", new[] { "TipoLinea_TipoLineaID" });
            DropIndex("dbo.LineaTelefonica", new[] { "AdministradorLineaID" });
            DropIndex("dbo.LineaTelefonica", new[] { "LineaTelefonicaID" });
            DropIndex("dbo.Contrato", new[] { "ContratoID" });
            DropIndex("dbo.Venta", new[] { "TipoPago_TipoPagoID" });
            DropIndex("dbo.Venta", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Venta", new[] { "CentroAtencionID" });
            DropIndex("dbo.Provincia", new[] { "DepartamentoID" });
            DropIndex("dbo.Distrito", new[] { "ProvinciaID" });
            DropIndex("dbo.Direccion", new[] { "DistritoID" });
            DropIndex("dbo.Direccion", new[] { "DireccionID" });
            DropIndex("dbo.Evaluacion", new[] { "TipoEvaluacion_TipoEvaluacionID" });
            DropIndex("dbo.Evaluacion", new[] { "Plan_PlanID" });
            DropIndex("dbo.Evaluacion", new[] { "LineaTelefonica_LineaTelefonicaID" });
            DropIndex("dbo.Evaluacion", new[] { "EstadoEvaluacion_EstadoEvaluacionID" });
            DropIndex("dbo.Evaluacion", new[] { "EquipoCelular_EquipoCelularID" });
            DropIndex("dbo.Evaluacion", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Evaluacion", new[] { "CentroAtencionID" });
            DropIndex("dbo.Evaluacion", new[] { "TrabajadorID" });
            DropIndex("dbo.Evaluacion", new[] { "EvaluacionID" });
            DropIndex("dbo.EquipoCelular", new[] { "AdministradorEquipoID" });
            DropTable("dbo.TipoTrabajador");
            DropTable("dbo.Trabajor");
            DropTable("dbo.TipoEvaluacion");
            DropTable("dbo.TipoPlan");
            DropTable("dbo.Plan");
            DropTable("dbo.EstadoEvaluacion");
            DropTable("dbo.TipoPago");
            DropTable("dbo.TipoLinea");
            DropTable("dbo.AdministradorLinea");
            DropTable("dbo.LineaTelefonica");
            DropTable("dbo.Contrato");
            DropTable("dbo.Cliente");
            DropTable("dbo.Venta");
            DropTable("dbo.Departamento");
            DropTable("dbo.Provincia");
            DropTable("dbo.Distrito");
            DropTable("dbo.Direccion");
            DropTable("dbo.CentroAtencion");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.EquipoCelular");
            DropTable("dbo.AdministradorEquipo");
        }
    }
}
