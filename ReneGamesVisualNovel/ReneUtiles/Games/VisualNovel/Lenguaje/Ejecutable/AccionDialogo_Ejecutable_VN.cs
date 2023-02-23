/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 17:02
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Dialogo;
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable
{
	/// <summary>
	/// Description of AccionDialogo_Ejecutable_VN.
	/// </summary>
	public class AccionDialogo_Ejecutable_VN:AccionDialogo_VN  
	{
		public Action<ContextoDeDialogo_VN> Accion;
		public AccionDialogo_Ejecutable_VN(Action<ContextoDeDialogo_VN> accion)
		{
			this.Accion=accion;
		}
	}
}
