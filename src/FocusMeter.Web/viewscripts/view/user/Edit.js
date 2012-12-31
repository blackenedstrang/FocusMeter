Ext.define('TP.view.user.Edit', {
	extend   : 'Ext.window.Window',
	alias    : 'widget.edituser',
	title    : 'Edit User',
	layout   : 'fit',
	autoShow : true,
	
	initComponent : function () {
		this.items = [{
			xtype : 'form',
			items : [{
					xtype: 'textfield',
					name: 'name',
					fieldLabel: 'User Name'
				}, {
					xtype: 'textfield',
					name: 'email',
					fieldLabel: 'User Email'
				}]
		}];

		this.buttons = [{
			text   : 'Save',
			action : 'save'
		}, {
			text    : 'Cancel',
			scope   : this,
			handler : function () {
				this.close();
			}
		}];

		this.callParent(arguments);
	}
});