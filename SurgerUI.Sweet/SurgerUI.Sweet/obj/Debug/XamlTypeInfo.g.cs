﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace SurgerUI.Sweet
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlTypeInfoProvider _provider;

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.String fullName)
        {
            if(_provider == null)
            {
                _provider = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo
{
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            string standardName;
            global::Windows.UI.Xaml.Markup.IXamlType xamlType = null;
            if(_xamlTypeToStandardName.TryGetValue(type, out standardName))
            {
                xamlType = GetXamlTypeByName(standardName);
            }
            else
            {
                xamlType = GetXamlTypeByName(type.FullName);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (global::System.String.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypes.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            xamlType = CreateXamlType(typeName);
            if (xamlType != null)
            {
                _xamlTypes.Add(typeName, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (global::System.String.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType> _xamlTypes = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();
        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember> _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();
        global::System.Collections.Generic.Dictionary<global::System.Type, string> _xamlTypeToStandardName = new global::System.Collections.Generic.Dictionary<global::System.Type, string>();

        private void AddToMapOfTypeToStandardName(global::System.Type t, global::System.String str)
        {
            if(!_xamlTypeToStandardName.ContainsKey(t))
            {
                _xamlTypeToStandardName.Add(t, str);
            }
        }

        private object Activate_3_GridviewSampleDataSource() { return new global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GridviewSampleDataSource(); }

        private object Activate_4_Groups() { return new global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.Groups(); }

        private object Activate_5_ObservableCollection() { return new global::System.Collections.ObjectModel.ObservableCollection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>(); }

        private object Activate_6_Collection() { return new global::System.Collections.ObjectModel.Collection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>(); }

        private object Activate_7_GroupsItem() { return new global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem(); }

        private object Activate_8_MainPage() { return new global::SurgerUI.Sweet.MainPage(); }

        private void VectorAdd_4_Groups(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>)instance;
            var newItem = (global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem)item;
            collection.Add(newItem);
        }

        private void VectorAdd_5_ObservableCollection(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>)instance;
            var newItem = (global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem)item;
            collection.Add(newItem);
        }

        private void VectorAdd_6_Collection(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>)instance;
            var newItem = (global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem)item;
            collection.Add(newItem);
        }


        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(string typeName)
        {
            global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType userType;

            switch (typeName)
            {
            case "Object":
                xamlType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::System.Object));
                break;

            case "String":
                xamlType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::System.String));
                break;

            case "Double":
                xamlType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::System.Double));
                break;

            case "Windows.UI.Xaml.Controls.Page":
                xamlType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::Windows.UI.Xaml.Controls.Page));
                break;

            case "Windows.UI.Xaml.Controls.UserControl":
                xamlType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::Windows.UI.Xaml.Controls.UserControl));
                break;

            case "Windows.UI.Color":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::Windows.UI.Color), GetXamlTypeByName("System.ValueType"));
                userType.AddMemberName("A");
                AddToMapOfTypeToStandardName(typeof(global::System.Byte),
                                                   "Byte");
                userType.AddMemberName("B");
                AddToMapOfTypeToStandardName(typeof(global::System.Byte),
                                                   "Byte");
                userType.AddMemberName("G");
                AddToMapOfTypeToStandardName(typeof(global::System.Byte),
                                                   "Byte");
                userType.AddMemberName("R");
                AddToMapOfTypeToStandardName(typeof(global::System.Byte),
                                                   "Byte");
                xamlType = userType;
                break;

            case "System.ValueType":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::System.ValueType), GetXamlTypeByName("Object"));
                xamlType = userType;
                break;

            case "Byte":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::System.Byte), GetXamlTypeByName("System.ValueType"));
                AddToMapOfTypeToStandardName(typeof(global::System.Byte),
                                                   "Byte");
                xamlType = userType;
                break;

            case "SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GridviewSampleDataSource":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GridviewSampleDataSource), GetXamlTypeByName("Object"));
                userType.Activator = Activate_3_GridviewSampleDataSource;
                userType.AddMemberName("Groups");
                xamlType = userType;
                break;

            case "SurgerUI.Sweet.SampleData.GridviewSampleDataSource.Groups":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.Groups), GetXamlTypeByName("System.Collections.ObjectModel.ObservableCollection<SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>"));
                userType.Activator = Activate_4_Groups;
                userType.CollectionAdd = VectorAdd_4_Groups;
                xamlType = userType;
                break;

            case "System.Collections.ObjectModel.ObservableCollection<SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::System.Collections.ObjectModel.ObservableCollection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>), GetXamlTypeByName("System.Collections.ObjectModel.Collection<SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>"));
                AddToMapOfTypeToStandardName(typeof(global::System.Collections.ObjectModel.ObservableCollection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>),
                                                   "System.Collections.ObjectModel.ObservableCollection<SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>");
                userType.Activator = Activate_5_ObservableCollection;
                userType.CollectionAdd = VectorAdd_5_ObservableCollection;
                xamlType = userType;
                break;

            case "System.Collections.ObjectModel.Collection<SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::System.Collections.ObjectModel.Collection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>), GetXamlTypeByName("Object"));
                AddToMapOfTypeToStandardName(typeof(global::System.Collections.ObjectModel.Collection<global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>),
                                                   "System.Collections.ObjectModel.Collection<SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem>");
                userType.Activator = Activate_6_Collection;
                userType.CollectionAdd = VectorAdd_6_Collection;
                xamlType = userType;
                break;

            case "SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem), GetXamlTypeByName("Object"));
                userType.Activator = Activate_7_GroupsItem;
                userType.AddMemberName("Property1");
                AddToMapOfTypeToStandardName(typeof(global::System.String),
                                                   "String");
                userType.AddMemberName("Property2");
                AddToMapOfTypeToStandardName(typeof(global::System.Double),
                                                   "Double");
                xamlType = userType;
                break;

            case "SurgerUI.Sweet.MainPage":
                userType = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::SurgerUI.Sweet.MainPage), GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_8_MainPage;
                xamlType = userType;
                break;

            }
            return xamlType;
        }


        private object get_0_Color_A(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.A;
        }
        private void set_0_Color_A(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.A = (global::System.Byte)Value;
        }
        private object get_1_Color_B(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.B;
        }
        private void set_1_Color_B(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.B = (global::System.Byte)Value;
        }
        private object get_2_Color_G(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.G;
        }
        private void set_2_Color_G(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.G = (global::System.Byte)Value;
        }
        private object get_3_Color_R(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.R;
        }
        private void set_3_Color_R(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.R = (global::System.Byte)Value;
        }
        private object get_4_GridviewSampleDataSource_Groups(object instance)
        {
            var that = (global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GridviewSampleDataSource)instance;
            return that.Groups;
        }
        private object get_5_GroupsItem_Property1(object instance)
        {
            var that = (global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem)instance;
            return that.Property1;
        }
        private void set_5_GroupsItem_Property1(object instance, object Value)
        {
            var that = (global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem)instance;
            that.Property1 = (global::System.String)Value;
        }
        private object get_6_GroupsItem_Property2(object instance)
        {
            var that = (global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem)instance;
            return that.Property2;
        }
        private void set_6_GroupsItem_Property2(object instance, object Value)
        {
            var that = (global::SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem)instance;
            that.Property2 = (global::System.Double)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlMember xamlMember = null;
            global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "Windows.UI.Color.A":
                userType = (global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlMember(this, "A", "Byte");
                xamlMember.Getter = get_0_Color_A;
                xamlMember.Setter = set_0_Color_A;
                break;
            case "Windows.UI.Color.B":
                userType = (global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlMember(this, "B", "Byte");
                xamlMember.Getter = get_1_Color_B;
                xamlMember.Setter = set_1_Color_B;
                break;
            case "Windows.UI.Color.G":
                userType = (global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlMember(this, "G", "Byte");
                xamlMember.Getter = get_2_Color_G;
                xamlMember.Setter = set_2_Color_G;
                break;
            case "Windows.UI.Color.R":
                userType = (global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlMember(this, "R", "Byte");
                xamlMember.Getter = get_3_Color_R;
                xamlMember.Setter = set_3_Color_R;
                break;
            case "SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GridviewSampleDataSource.Groups":
                userType = (global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType)GetXamlTypeByName("SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GridviewSampleDataSource");
                xamlMember = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlMember(this, "Groups", "SurgerUI.Sweet.SampleData.GridviewSampleDataSource.Groups");
                xamlMember.Getter = get_4_GridviewSampleDataSource_Groups;
                xamlMember.SetIsReadOnly();
                break;
            case "SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem.Property1":
                userType = (global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType)GetXamlTypeByName("SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem");
                xamlMember = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlMember(this, "Property1", "String");
                xamlMember.Getter = get_5_GroupsItem_Property1;
                xamlMember.Setter = set_5_GroupsItem_Property1;
                break;
            case "SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem.Property2":
                userType = (global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlUserType)GetXamlTypeByName("SurgerUI.Sweet.SampleData.GridviewSampleDataSource.GroupsItem");
                xamlMember = new global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlMember(this, "Property2", "Double");
                xamlMember.Getter = get_6_GroupsItem_Property2;
                xamlMember.Setter = set_6_GroupsItem_Property2;
                break;
            }
            return xamlMember;
        }

    }

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(global::System.String input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlSystemBaseType
    {
        global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public global::System.Object CreateFromString(global::System.String input)
        {
            if (_enumValues != null)
            {
                global::System.Int32 value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    global::System.Int32 enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( global::System.String.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::SurgerUI.Sweet.SurgerUI_Sweet_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(global::System.String targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}


