namespace UnityEngine
{
    using System.Collections.Generic;
    using System.Linq;

    public static class CameraExtensions
    {
        public static bool IsObjectVisible(this UnityEngine.Camera @this, Renderer renderer)
        {
            if (renderer == null) return false;
            return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), renderer.bounds);
        }

        public static bool IsObjectVisible(this UnityEngine.Camera @this, Renderer[] renderers)
        {
            if (renderers == null || renderers.Length <= 0) return false;
            return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), renderers.EncapsulatedBounds());
        }
    }

    public static class BoundsExtensions
    {
        public static Bounds EncapsulatedBounds(this IEnumerable<Renderer> renderers)
        {
            return renderers.Select(renderer => renderer.bounds).Encapsulation();
        }

        public static Bounds EncapsulatedBounds(this IEnumerable<Mesh> meshes)
        {
            return meshes.Select(mesh => mesh.bounds).Encapsulation();
        }

        public static Bounds Encapsulation(this IEnumerable<Bounds> bounds)
        {
            return bounds.Aggregate((encapsulation, next) =>
            {
                encapsulation.Encapsulate(next);
                return encapsulation;
            });
        }
    }
}