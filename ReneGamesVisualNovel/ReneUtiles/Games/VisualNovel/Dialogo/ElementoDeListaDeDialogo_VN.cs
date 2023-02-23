/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 6/5/2022
 * Hora: 12:00
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Clases.Condicionales;
using ReneUtiles.Games.VisualNovel.Visualizacion;
using ReneUtiles.Games.VisualNovel.Personajes;
using ReneUtiles.Games.VisualNovel.Progresos;
using ReneUtiles.Games.VisualNovel.Dialogo.Creadores;

using ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo;
using ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable;
using ReneUtiles.Clases.LeguajeDescritivo.Metodos;
namespace ReneUtiles.Games.VisualNovel.Dialogo
{
	/// <summary>
	/// Description of ElementoDeListaDeDialogo.
	/// </summary>
	public class ElementoDeListaDeDialogo_VN:CreadorDeElementoDeListaDeDialogo_VN
	{
		//public TextoVisual_VN TextoDeOpcion;
		//public FondoVisual_VN Fondo;
		
		public Func<ContextoDeDialogo_VN,TextoVisual_VN> GetTextoDeOpcion;
		
		public CondicionDeVisbilidadDeOpcion_VN Condicion;
		public TransicionDeDialogo_VN TrasicionASiguienteElemento;
		
		//public Action<ContextoDeDialogo_VN> AccionAlTerminar;
		public AccionDialogo_VN AccionAlTerminar;
		
		//public
		
		private bool usarLenguajeDescriptivo = true;
		
		public ElementoDeListaDeDialogo_VN(string texto)
		{
			this.GetTextoDeOpcion = ctx => new TextoVisual_VN(texto);
			if (usarLenguajeDescriptivo) {
				this.Condicion = new CondicionDeVisbilidadDeOpcion_Descriptiva_VN(new TRUE_Condicional());
			} else {
				this.Condicion = new CondicionDeVisbilidadDeOpcion_Ejecutable_VN(ctx => true);
			}
			//
			
			
			
		}
		public string getTextoPlano(ContextoDeDialogo_VN ctx)
		{
			return this.GetTextoDeOpcion(ctx).TextoPlano;
		}
		
		//		public bool esVisble(ContextoDeDialogo_VN ctx){
		//			return this.Condicion.seCumple(ctx);
		//		}
		public ElementoDeListaDeDialogo_VN _if(params Etapa_VN[] etapas)
		{
			if (usarLenguajeDescriptivo) {
			
			
				CondicionDeVisbilidadDeOpcion_Descriptiva_VN c = (CondicionDeVisbilidadDeOpcion_Descriptiva_VN)this.Condicion;
			
				foreach (Etapa_VN e in etapas) {
					c.Condicion = new AND_Condicional(c.Condicion, e);
				}
			} else {
				CondicionDeVisbilidadDeOpcion_Ejecutable_VN c = (CondicionDeVisbilidadDeOpcion_Ejecutable_VN)this.Condicion;
				c.Condicion = ctx => {
					if (c.Condicion(ctx)) {
						foreach (Etapa_VN e in etapas) {
							if (!e.Completado) {
								return false;
							}
						}
						return true;
					}
					return false;
				};
			}
			
			
			
			
			return this;
		}
		public ElementoDeListaDeDialogo_VN _ifnot(params Etapa_VN[] etapas)
		{
			if (usarLenguajeDescriptivo) {
				CondicionDeVisbilidadDeOpcion_Descriptiva_VN c = (CondicionDeVisbilidadDeOpcion_Descriptiva_VN)this.Condicion;
			
			
				foreach (Etapa_VN e in etapas) {
					c.Condicion = new AND_Condicional(c.Condicion, new NOT_Condicional(e));
				}
			} else {
				CondicionDeVisbilidadDeOpcion_Ejecutable_VN c = (CondicionDeVisbilidadDeOpcion_Ejecutable_VN)this.Condicion;
				c.Condicion = ctx => {
					if (c.Condicion(ctx)) {
						foreach (Etapa_VN e in etapas) {
							if (e.Completado) {
								return false;
							}
						}
						return true;
					}
					return false;
				};
			}
			
			
			return this;
		}
		public ElementoDeListaDeDialogo_VN end(params Etapa_VN[] etapasACompletar)
		{
			if (usarLenguajeDescriptivo) {
				Algoritmo accion = new CompletarEtapas_Descriptivo_VN(etapasACompletar);
				if (this.AccionAlTerminar == null) {
					this.AccionAlTerminar = new AccionDialogo_Descriptiva_VN(accion); 
				} else {
					AccionDialogo_Descriptiva_VN a = (AccionDialogo_Descriptiva_VN)AccionAlTerminar;
					accion.Antes.Add(a.Accion);
					this.AccionAlTerminar = a;
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
//			foreach (Etapa_VN etapaACompletar in etapasACompletar) {
//				Action<ContextoDeDialogo_VN> accion = ctx => {
//					if (etapaACompletar.CondicionDeInicio.seCumple()) {
//						etapaACompletar.Completado = true;
//					}
//				};
//				if (this.AccionAlTerminar == null) {
//					this.AccionAlTerminar = accion;
//				} else {
//					this.AccionAlTerminar = ctx => {
//						this.AccionAlTerminar(ctx);
//						accion(ctx);
//					};
//				}
//			}
			
			
			return this;
		}
		public  ElementoDeListaDeDialogo_VN crearElementoDeListaDeDialogo()
		{
			return this;
		}
	}
}
