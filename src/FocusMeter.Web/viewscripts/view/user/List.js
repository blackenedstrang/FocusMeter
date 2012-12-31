Ext.define('TP.view.user.List', {
	extend : 'Ext.grid.Panel',
	alias  : 'widget.userlist',
	title  : 'All Users',
	store  : 'UserStore',
	
	initComponent: function () {

		this.columns = [
			{ header: 'name', dataIndex: 'name', flex: 1 },
			{ header: 'email', dataIndex: 'email', flex: 1 }
		];

		this.callParent(arguments);
	}
});