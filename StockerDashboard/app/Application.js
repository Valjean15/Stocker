/**
 * Inicio de la aplicacion cuando es inciado por un movil
 */
Ext.define('StockerDashboard.Application', {
    extend: 'Ext.app.Application',
    
    /**
     * Nombre de la aplicacion
     */
    name: 'StockerDashboard',

    /**
     * Ventana de entrada
     */
    defaultToken : 'dashboard',

    /**
     * Ventana principal
     */
    mainView: 'StockerDashboard.view.main.Main',

    /**
     * Perfiles de entrada
     */
    profiles: [
        //'Phone',
        //'Tablet'
    ],

    /**
     * Stores compartidados
     */
    stores: [
        'NavigationTree'
    ]
});
