/**
 * Singleton de iconos de la aplicacion
 */
Ext.define('StockerDashboard.singleton.Icon', {
    singleton: true,
    alternateClassName: ['Icon'],

    /**
     * Constructo de la clase
     * @param {*} config - Configuracion de la clase
     */
    constructor: function (config) {
        this.initConfig(config);
    },

    /**
     * Variables de la clase
     */
    config: {
        prefix:             'x-fa',
        shoppingCart:       'fa-shopping-cart',
        plusCircle:         'fa-plus-circle',
        file:               'fa-file',
        tasks:              'fa-tasks',
        archive:            'fa-archive',
        desktop:            'fa-desktop'
    },

    /**
     * Obtiene icono con nombre completo
     * @param {String} icon - Icono a obtener
     */
    get: function (icon) {
        var selectedIcon = Icon.config[icon];
        return !selectedIcon ? '': Ext.String.format('{0} {1}', Icon.getPrefix(), selectedIcon);
    }
});