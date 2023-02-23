/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 5/5/2022
 * Hora: 19:38
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Visualizacion;
using ReneUtiles.Games.VisualNovel.Personajes;
using ReneUtiles.Games.VisualNovel.Partida;
using ReneUtiles.Games.VisualNovel.Progresos;
using ReneUtiles.Games.VisualNovel.Dialogo.Creadores;

using ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo;
using ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable;

using ReneUtiles.Clases.LeguajeDescritivo.Metodos;
namespace ReneUtiles.Games.VisualNovel.Dialogo
{
	/// <summary>
	/// Description of ElementoDeDialgo_VN.
	/// </summary>
	public class ElementoDeDialgo_VN:Escenario_VN,CreadorDeElementoDeDialogo_VN
	{
		//public TextoVisual_VN TextoDeDialogo;
		public Func<ContextoDeDialogo_VN,TextoVisual_VN> GetTextoDeDialogo;
		
		
		public Personaje_VN Personaje;
		public AccionDialogo_VN AccionAlTerminar;
		public TransicionDeDialogo_VN TrasicionASiguienteElemento;
		public string Nombre, Descripcion;
		
		private bool usarLenguajeDescriptivo = true;
		
		
		public ElementoDeDialgo_VN(Personaje_VN personaje, string nombre = null, string texto = null, string descripcion = null)
		{
			this.Nombre = nombre;
			this.Descripcion = descripcion;
			//this.TextoDeDialogo=new TextoVisual_VN(texto);
			
			this.Personaje = personaje;
			
			this.GetTextoDeDialogo = ctx => new TextoVisual_VN(texto);
		}
		
		public string getTextoPlano(ContextoDeDialogo_VN ctx)
		{
			return this.GetTextoDeDialogo(ctx).TextoPlano;
		}
		
		public  ElementoDeDialgo_VN crearElementoDeDialogo()
		{
			return this;
		}
		
		
		public ElementoDeDialgo_VN end(params Etapa_VN[] etapasACompletar)
		{
			if (usarLenguajeDescriptivo) {
				Algoritmo accion=new CompletarEtapas_Descriptivo_VN(etapasACompletar);
				if(this.AccionAlTerminar==null){
					this.AccionAlTerminar = new AccionDialogo_Descriptiva_VN(accion); 
				}else{
					AccionDialogo_Descriptiva_VN a = (AccionDialogo_Descriptiva_VN)AccionAlTerminar;
					accion.Antes.Add(a.Accion);
					this.AccionAlTerminar=a;
				}
				
			} else {
				
				
				
				foreach (Etapa_VN etapaACompletar in etapasACompletar) {
					Action<ContextoDeDialogo_VN> accion = ctx => {
						if (((CondicionDeEtapa_Ejecutable_VN)etapaACompletar.CondicionDeInicio).seCumple()) {
							etapaACompletar.Completado = true;
						}
					};
					if (this.AccionAlTerminar == null) {
						this.AccionAlTerminar = new AccionDialogo_Ejecutable_VN(accion);
					} else {
						AccionDialogo_Ejecutable_VN a = (AccionDialogo_Ejecutable_VN)AccionAlTerminar;
						a.Accion = ctx => {
							a.Accion(ctx);
							accion(ctx);
						};
					}
				}
				
			}
			
			
			
			
			return this;
		}
		
	}
}
