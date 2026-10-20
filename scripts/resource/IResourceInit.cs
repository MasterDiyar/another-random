using Godot;

namespace trash.scripts.resource;

public interface IResourceInit<T> where T : Resource
{
    T Copy();
}