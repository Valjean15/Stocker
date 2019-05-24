/**
 * Componente basico
 */
Ext.define('StockerDashboard.view.widgets.StatusTile', {
    extend: 'Ext.Component',
    xtype: 'statustile',

    /**
     * Configuraciones del componente
     */
    config: {

        /**
         * Color de fondo a utilizar. Valor del color en Hexadecimal
         */
        color: null,

        /**
         * Icono a mostrar
         */
        iconCls: null,

        /**
         * Indica si mostrar primero el icono
         */
        iconFirst: false,

        /**
         * Indica el tamaño del componente
         * - large
         */
        scale: null,

        /**
         * Descripcion a mostrar en el componente
         */
        description: null,

        /**
         * Valor a mostrar en el componente
         */
        text: null
    },

    /**
     * Estructura el componente
     */
    element: {
        reference: 'element',
        cls: 'status-tile',

        children: [{
            cls: 'status-tile-wrap',

            children: [{
                reference: 'quantityElement',
                cls: 'status-tile-quantity'
            }, {
                reference: 'descriptionElement',
                cls: 'status-tile-description'
            }, {
                cls: 'status-tile-icon-wrap',
                reference: 'iconWrapElement',

                children: [{
                    reference: 'iconElement',
                    cls: 'status-tile-icon'
                }]
            }]
        }]
    },

    /**
     * Asigna al componente un color de fondo
     * @param {String} value - Valor Hexadecimal
     */
    updateColor: function (value) {
        this.element.setStyle('borderTopColor', value);
        this.syncIconBackground();
    },

    /**
     * Agrega una descripcion al componente
     * @param {String} value - Descripcion
     */
    updateDescription: function (value) {
        this.setTextContent('descriptionElement', value);
    },

    /**
     * Actualiza el icono el componente
     * @param {String} value - Icono nuevo
     * @param {String} oldValue - Icono anterior
     */
    updateIconCls: function (value, oldValue) {
        this.iconElement.replaceCls(oldValue, value);
    },

    /**
     * Indica si el icono del componente ira de primero
     * @param {Boolean} value - True/False
     */
    updateIconFirst: function (value) {
        var iconEl = this.iconElement.dom.parentNode,
            quantityEl = this.quantityElement.dom;

        quantityEl.parentNode.insertBefore(iconEl, value ? quantityEl : null);

        this.element.toggleCls('status-tile-icon-first', value);

        this.syncIconBackground();
    },

    /**
     * Valor a mostrar en el centro del componente
     * @param {Number} value - Valor a mostrar
     */
    updateText: function (value) {
        this.setTextContent('quantityElement', value);
    },

    /**
     * Cambia el tamaño del componente
     * @param {String} value - Tamaño nuevo
     * @param {String} oldValue - Tamaño anterior
     */
    updateScale: function (value, oldValue) {
        var me = this,
            was = me.getBaseTileCls(oldValue),
            is = me.getBaseTileCls(value);

        me.element.replaceCls(was, is);
    },

    /**
     * Funciones privadas del componente
     */
    privates: {
        /**
         * Obtiene el sass del tamaño del componente
         * @param {String} scale - Valor de tamaño del componente
         */
        getBaseTileCls: function (scale) {
            return scale ? 'status-tile-' + scale : '';
        },

        /**
         * Agrega en el contenido de una etiqueta contenido 
         * @param {String} el - Etiqueta
         * @param {String} text - Valor
         */
        setTextContent: function (el, text) {
            this[el].dom.textContent = text;
        },

        /**
         * Pinta el color de fondo del componente
         */
        syncIconBackground: function () {
            var background = this.getIconFirst() ? this.getColor() : '';
            this.iconWrapElement.setStyle('backgroundColor', background);
        }
    }
});
