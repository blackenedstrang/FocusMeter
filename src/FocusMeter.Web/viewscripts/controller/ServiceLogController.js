Ext.define('TP.controller.ServiceLogController', {
	extend: 'Ext.app.Controller',
	views: [
		'servicelogs.List',
		'servicelogs.Details'
	],
	stores: [
		'ServiceLogStore'
	],
	models: [
		'ServiceLogModel'
	],
	init: function () {
		
		this.control({
			'logslist' : {
				itemdblclick: function (grid, record) {
					var details = Ext.widget('detail');
					details.down('form').loadRecord(record);
				}
			}
		});
	}
});