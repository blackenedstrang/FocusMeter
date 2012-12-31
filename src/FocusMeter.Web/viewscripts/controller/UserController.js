Ext.define('TP.controller.UserController', {
	extend: 'Ext.app.Controller',
	views: [
		'user.List',
		'user.Edit'
	],

	stores: [
		'UserStore'
	],

	models: [
		'UserModel'
	],

	init: function () {
		this.control({
			'userlist': {
				itemdblclick: function (grid, record) {
					var edituserWindow = Ext.widget('edituser');
					edituserWindow.down('form').loadRecord(record);
				}
			},
			'edituser button[action=save]': {
				click: function (button) {
					var window = button.up('window');
					var form = window.down('form');
					var record = form.getRecord();
					var values = form.getValues();
					record.set(values);
					window.close();
				}
			}
		});
	}
});