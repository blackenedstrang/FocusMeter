Ext.define('TP.view.servicelogs.List', {
	extend: 'Ext.grid.Panel',
	alias: 'widget.logslist',
	title: 'Services Logs',
	store: 'ServiceLogStore',

	initComponent: function () {
		this.columns = [
			{ header: 'Log Application Type', dataIndex: 'LogApplicationType', flex: 1 },
			{ header: 'Action', dataIndex: 'Action', flex: 1 },
			{ header: 'ElapsedTime', dataIndex: 'ElapsedTime'}, 
			{ header: 'Date', dataIndex: 'CreatedDate', flex: 1 }
		];
		
		this.callParent(arguments);
	}
})