/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 15:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Clases.Condicionales;
using ReneUtiles.Games.VisualNovel.Dialogo;
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo
{
	/// <summary>
	/// Description of CondicionDeVisbilidadDeOpcion_Descriptiva_VN.
	/// </summary>
	public class CondicionDeVisbilidadDeOpcion_Descriptiva_VN:CondicionDeVisbilidadDeOpcion_VN 
	{
		public Condicional Condicion;
		public CondicionDeVisbilidadDeOpcion_Descriptiva_VN(Condicional condicion)
		{
			this.Condicion=condicion;
		}
	}
}
