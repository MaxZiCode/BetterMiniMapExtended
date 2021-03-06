using Verse;

namespace BetterMiniMap.Overlays
{
	public class Viewpoint_Overlay : Overlay
	{
        public Viewpoint_Overlay(bool visible = true) : base(visible) { }

        public override int GetUpdateInterval() => BetterMiniMapMod.settings.updatePeriods.viewpoint;

		public override void Render()
		{
            IntVec3 shadow;
            foreach (IntVec3 current in Find.CameraDriver.CurrentViewRect.EdgeCells)
            {
				if (current.InBounds(Find.VisibleMap))
					base.Texture.SetPixel(current.x, current.z, BetterMiniMapMod.settings.overlayColors.viewpoint);
                shadow = new IntVec3(current.x - 1, 0, current.y + 1);
				if (shadow.InBounds(Find.VisibleMap))
					base.Texture.SetPixel(shadow.x, shadow.z, BetterMiniMapMod.settings.overlayColors.viewpointFaded);
            }
        }
	}
}
