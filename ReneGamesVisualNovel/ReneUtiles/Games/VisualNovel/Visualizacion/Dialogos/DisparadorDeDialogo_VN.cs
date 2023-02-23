/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 13:52
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Dialogo;
namespace ReneUtiles.Games.VisualNovel.Visualizacion.Dialogos
{
	/// <summary>
	/// Description of DisparadorDeDialogo_VN.
	/// </summary>
	public class DisparadorDeDialogo_VN
	{
		public CondicionDeVisbilidadDeDialogo_VN condicionDeVisibilidad;
		public Dialogo_VN Dialogo;
		
		private bool usarLenguajeDescriptivo = true;
		public DisparadorDeDialogo_VN()
		{
		}
	}
}
