Ext.define('TP.model.ServiceLogModel', {
	extend: 'Ext.data.Model',
	fields: [
		{ name: 'Id', type: 'int' },
		{ name: 'LogApplicationType', type: 'string' },
		{ name: 'Request', type: 'string' },
		{ name: 'CreatedDate', type: 'date', dateFormat: 'MS' },
		{ name: 'Response', type: 'string' },
		{ name: 'Action', type: 'string' },
		{ name: 'ElapsedTime', type: 'auto' }
	]
})