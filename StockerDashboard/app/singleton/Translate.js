/**
 * Singleton de iconos de la aplicacion
 */
Ext.define('StockerDashboard.singleton.Translate', {
    singleton: true,
    alternateClassName: ['Translate'],

    /**
     * Constructor de la clase
     * @param {*} config - Configuracion de la clase
     */
    constructor: function (config) {
        this.initConfig(config);
    },

    /**
     * Variables de la clase
     */
    config: {
        store: null
    },

    /**
     * Obtiene traduccion de una llave
     * @param {String} key - Traduccion a obtener
     */
    get: function (key) {
        var store = this.getStore();
        if (!store) {
            this.setStore(this.declareStore());
            var store = this.getStore();
        }

        var query = store.query('key', key);
        if (query.count() == 0) return Ext.String.format('_{0}', key);

        var value = query.first().get('value');
        return !value ? Ext.String.format('_{0}', key) : value;
    },

    privates: {
        /**
         * Obtiene store de lenguaje
         * @returns {Ext.data.Store}
         */
        declareStore: function () {
            return new Ext.data.Store({
                autoLoad: true,
                fields: [
                    { name: 'key', type: 'string' },
                    { name: 'value', type: 'string' },
                ],
                data: this.determineLocale(),
                proxy: {
                    type: 'memory',
                    reader: { type: 'json', rootProperty: 'data' }
                }
            });
        },

        /**
         * Determina que lenguaje ocupara
         * @returns {StockerDashboard.data.language.*}
         */
        determineLocale: function(){
            try {
                if (!localStorage.locale) localStorage.locale = 'en';
                return Ext.create(Ext.String.format('StockerDashboard.data.language.Locale_{0}', localStorage.locale))
            } catch (error) {
                return new StockerDashboard.data.language.Locale_en();
            }        
        }
    }
});