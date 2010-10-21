
//------------------------------------------------------------------------------

// <auto-generated>

//     This code was generated from a template.

//

//     Changes to this file may cause incorrect behavior and will be lost if

//     the code is regenerated.

// </auto-generated>

//------------------------------------------------------------------------------

 

using System;

using System.Collections;

using System.Collections.Generic;

using System.Collections.ObjectModel;

using System.Collections.Specialized;




namespace KillSwitchEngage.Data

{

    
    public partial class ContactType : System.ComponentModel.INotifyPropertyChanged
    
    {
    
          public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
          protected void RaisePropertyChanged(string propertyName)
    
          {
    
                if (PropertyChanged == null) return;
    
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    
          }
    
        #region Primitive Properties
    
     
    
        public virtual int ID
    
        {
    
    
            get { return _iD; }
    
            set {
    
                      _iD = value;
    
                      RaisePropertyChanged("ID");
    
                }
    
    
        }
    
    
        private int _iD;
    
    
     
    
        public virtual string Label
    
        {
    
    
            get { return _label; }
    
            set {
    
                      _label = value;
    
                      RaisePropertyChanged("Label");
    
                }
    
    
        }
    
    
        private string _label;
    

        #endregion
        #region Navigation Properties
    
     
    
    
        public virtual ICollection<CompanyContact> CompanyContacts
    
        {
    
            get
    
            {
    
                if (_companyContacts == null)
    
                {
    
    
                    var newCollection = new FixupCollection<CompanyContact>();
    
                    newCollection.CollectionChanged += FixupCompanyContacts;
    
                    _companyContacts = newCollection;
    
    
                }
    
                return _companyContacts;
    
            }
    
            set
    
            {
    
    
                if (!ReferenceEquals(_companyContacts, value))
    
                {
    
                    var previousValue = _companyContacts as FixupCollection<CompanyContact>;
    
                    if (previousValue != null)
    
                    {
    
                        previousValue.CollectionChanged -= FixupCompanyContacts;
    
                    }
    
                    _companyContacts = value;
    
                            RaisePropertyChanged("CompanyContacts");     
    
                    var newValue = value as FixupCollection<CompanyContact>;
    
                    if (newValue != null)
    
                    {
    
                        newValue.CollectionChanged += FixupCompanyContacts;
    
                    }
    
                }
    
    
            }
    
        }
    
        private ICollection<CompanyContact> _companyContacts;
    

        #endregion
        #region Association Fixup
    
     
    
        private void FixupCompanyContacts(object sender, NotifyCollectionChangedEventArgs e)
    
        {
    
            if (e.NewItems != null)
    
            {
    
                foreach (CompanyContact item in e.NewItems)
    
                {
    
    
                    item.ContactType = this;
    
    
                }
    
            }
    
     
    
            if (e.OldItems != null)
    
            {
    
                foreach (CompanyContact item in e.OldItems)
    
                {
    
    
                    if (ReferenceEquals(item.ContactType, this))
    
                    {
    
                        item.ContactType = null;
    
                    }
    
    
                }
    
            }
    
        }
    

        #endregion
    
    }
    

}

