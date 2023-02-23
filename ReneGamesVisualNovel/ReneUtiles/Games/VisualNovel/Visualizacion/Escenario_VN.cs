/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 6/5/2022
 * Hora: 14:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Partida;
using ReneUtiles.Games.VisualNovel.Visualizacion.Creadores;
namespace ReneUtiles.Games.VisualNovel.Visualizacion
{
	/// <summary>
	/// Description of Escenario_VN.
	/// </summary>
	public class Escenario_VN:CreadorDeEscenario_VN
	{	
		//public FondoVisual_VN Fondo;
		//public TransicionsVisual_VN transicionDeInicio;
		
		public Func<ContextoDePartida_VN,FondoVisual_VN> getFondoActual;
		public Func<ContextoDePartida_VN,TransicionsVisual_VN> getTransicionDeInicio;
		
		public Escenario_VN()
		{
		}
		public  Escenario_VN crearEscenario(){return this;}
		//public FondoVisual_VN getFondo(){}
	}
}
