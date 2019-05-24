/**
 * Componente con accion de redirecionar
 */
Ext.define('StockerDashboard.view.widgets.LinkedTile', {
    extend: 'StockerDashboard.view.widgets.StatusTile',
    xtype: 'linkedtile',

    /**
     * Configuraciones del componente
     */
    config:{
        /**
         * Accion a realizar con evento click
         */
        clickAction: null,
    },

    /**
     * Estructura el componente
     */
    element: {
        reference: 'element',
        cls: 'linked-tile',

        children: [{
            cls: 'linked-tile-wrap',

            children: [{
                reference: 'quantityElement',
                cls: 'linked-tile-quantity',
            }, {
                reference: 'descriptionElement',
                cls: 'linked-tile-description',
            }, {
                cls: 'linked-tile-icon-wrap',
                reference: 'iconWrapElement',

                children: [{
                    reference: 'iconElement',
                    cls: 'linked-tile-icon',
                }]
            }],
        }],
        listeners: {click: function(){}}
    },

    privates: {

        /**
         * Pinta el color de fondo del componente
         */
        syncIconBackground: function () {
            var iconEl = this.iconElement.dom.parentNode,
                quantityEl = this.quantityElement.dom;

            quantityEl.parentNode.insertBefore(iconEl, quantityEl);

            this.element.toggleCls('linked-tile-icon-first', true);
            this.iconWrapElement.setStyle('backgroundColor', this.getColor());
        }
    }
});
