using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    //
    // Summary:
    //     Represents a collection of System.Windows.Forms.Control objects.
    [ComVisible(false)]
    [ListBindable(false)]
    public class ControlCollection : IList<Component> , ICloneable
    {
        private List<Component> _components;
        private Component _owner;
        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.Control.ControlCollection
        //     class.
        //
        // Parameters:
        //   owner:
        //     A System.Windows.Forms.Control representing the control that owns the control
        //     collection.
        public ControlCollection(Component owner)
        {
            this._components = new List<Component>();
            this._owner = owner;
        }

        //
        // Summary:
        //     Indicates the System.Windows.Forms.Control at the specified indexed location
        //     in the collection.
        //
        // Parameters:
        //   index:
        //     The index of the control to retrieve from the control collection.
        //
        // Returns:
        //     The System.Windows.Forms.Control located at the specified index location within
        //     the control collection.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The index value is less than zero or is greater than or equal to the number of
        //     controls in the collection.
        public virtual Component this[int index] => this._components[index];
        //
        // Summary:
        //     Indicates a System.Windows.Forms.Control with the specified key in the collection.
        //
        // Parameters:
        //   key:
        //     The name of the control to retrieve from the control collection.
        //
        // Returns:
        //     The System.Windows.Forms.Control with the specified key within the System.Windows.Forms.Control.ControlCollection.
        Component IList<Component>.this[int index] 
        { 
            get => this._components[index];
            set => throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the control that owns this System.Windows.Forms.Control.ControlCollection.
        //
        // Returns:
        //     The System.Windows.Forms.Control that owns this System.Windows.Forms.Control.ControlCollection.
        public Component Owner => this._owner;

        public int Count => this._components.Count;

        public bool IsSynchronized => true;

        private object _syncObj1 = new object();
        public object SyncRoot => this._syncObj1;

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        //
        // Summary:
        //     Adds the specified control to the control collection.
        //
        // Parameters:
        //   value:
        //     The System.Windows.Forms.Control to add to the control collection.
        //
        // Exceptions:
        //   T:System.Exception:
        //     The specified control is a top-level control, or a circular control reference
        //     would result if this control were added to the control collection.
        //
        //   T:System.ArgumentException:
        //     The object assigned to the value parameter is not a System.Windows.Forms.Control.
        public virtual void Add(Component value)
        {
            this._components.Add(value);
        }

        //
        // Summary:
        //     Adds an array of control objects to the collection.
        //
        // Parameters:
        //   controls:
        //     An array of System.Windows.Forms.Control objects to add to the collection.
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual void AddRange(Component[] controls)
        {
            this._components.AddRange(controls);
        }
        //
        // Summary:
        //     Removes all controls from the collection.
        public virtual void Clear()
        {
            this._components.Clear();
        }

        public object Clone()
        {
            return new ControlCollection(this._owner) { _components = new List<Component>(this._components)};
        }

        //
        // Summary:
        //     Determines whether the specified control is a member of the collection.
        //
        // Parameters:
        //   control:
        //     The System.Windows.Forms.Control to locate in the collection.
        //
        // Returns:
        //     true if the System.Windows.Forms.Control is a member of the collection; otherwise,
        //     false.
        public bool Contains(Component control) => this._components.Contains(control);

        //
        // Summary:
        //     Determines whether the System.Windows.Forms.Control.ControlCollection contains
        //     an item with the specified key.
        //
        // Parameters:
        //   key:
        //     The key to locate in the System.Windows.Forms.Control.ControlCollection.
        //
        // Returns:
        //     true if the System.Windows.Forms.Control.ControlCollection contains an item with
        //     the specified key; otherwise, false.
        public virtual bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Component[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Searches for controls by their System.Windows.Forms.Control.Name property and
        //     builds an array of all the controls that match.
        //
        // Parameters:
        //   key:
        //     The key to locate in the System.Windows.Forms.Control.ControlCollection.
        //
        //   searchAllChildren:
        //     true to search all child controls; otherwise, false.
        //
        // Returns:
        //     An array of type System.Windows.Forms.Control containing the matching controls.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The key parameter is null or the empty string ("").
        public Component[] Find(string key, bool searchAllChildren)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Retrieves the index of the specified child control within the control collection.
        //
        // Parameters:
        //   child:
        //     The System.Windows.Forms.Control to search for in the control collection.
        //
        // Returns:
        //     A zero-based index value that represents the location of the specified child
        //     control within the control collection.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The childSystem.Windows.Forms.Control is not in the System.Windows.Forms.Control.ControlCollection.
        public int GetChildIndex(Component child)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Retrieves the index of the specified child control within the control collection,
        //     and optionally raises an exception if the specified control is not within the
        //     control collection.
        //
        // Parameters:
        //   child:
        //     The System.Windows.Forms.Control to search for in the control collection.
        //
        //   throwException:
        //     true to throw an exception if the System.Windows.Forms.Control specified in the
        //     child parameter is not a control in the System.Windows.Forms.Control.ControlCollection;
        //     otherwise, false.
        //
        // Returns:
        //     A zero-based index value that represents the location of the specified child
        //     control within the control collection; otherwise -1 if the specified System.Windows.Forms.Control
        //     is not found in the System.Windows.Forms.Control.ControlCollection.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The childSystem.Windows.Forms.Control is not in the System.Windows.Forms.Control.ControlCollection,
        //     and the throwException parameter value is true.
        public virtual int GetChildIndex(Component child, bool throwException)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Retrieves a reference to an enumerator object that is used to iterate over a
        //     System.Windows.Forms.Control.ControlCollection.
        //
        // Returns:
        //     An System.Collections.IEnumerator.
        public virtual IEnumerator GetEnumerator()
        {
            return this._components.GetEnumerator();
        }
        //
        // Summary:
        //     Retrieves the index of the specified control in the control collection.
        //
        // Parameters:
        //   control:
        //     The System.Windows.Forms.Control to locate in the collection.
        //
        // Returns:
        //     A zero-based index value that represents the position of the specified System.Windows.Forms.Control
        //     in the System.Windows.Forms.Control.ControlCollection.
        public int IndexOf(Component control)
        {
            return this._components.IndexOf(control);
        }

        //
        // Summary:
        //     Retrieves the index of the first occurrence of the specified item within the
        //     collection.
        //
        // Parameters:
        //   key:
        //     The name of the control to search for.
        //
        // Returns:
        //     The zero-based index of the first occurrence of the control with the specified
        //     name in the collection.
        public virtual int IndexOfKey(string key)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Component item)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Removes the specified control from the control collection.
        //
        // Parameters:
        //   value:
        //     The System.Windows.Forms.Control to remove from the System.Windows.Forms.Control.ControlCollection.
        public virtual void Remove(Component value)
        {

        }

        //
        // Summary:
        //     Removes a control from the control collection at the specified indexed location.
        //
        // Parameters:
        //   index:
        //     The index value of the System.Windows.Forms.Control to remove.
        public void RemoveAt(int index)
        {

        }
        //
        // Summary:
        //     Removes the child control with the specified key.
        //
        // Parameters:
        //   key:
        //     The name of the child control to remove.
        public virtual void RemoveByKey(string key)
        {

        }
        //
        // Summary:
        //     Sets the index of the specified child control in the collection to the specified
        //     index value.
        //
        // Parameters:
        //   child:
        //     The childSystem.Windows.Forms.Control to search for.
        //
        //   newIndex:
        //     The new index value of the control.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The child control is not in the System.Windows.Forms.Control.ControlCollection.
        public virtual void SetChildIndex(Component child, int newIndex)
        {

        }

        IEnumerator<Component> IEnumerable<Component>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        bool ICollection<Component>.Remove(Component item)
        {
            throw new NotImplementedException();
        }
    }
}
