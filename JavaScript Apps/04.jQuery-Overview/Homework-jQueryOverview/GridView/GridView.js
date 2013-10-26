$(document).ready(function () {
    /*------------------------ Grid view ------------------------*/
    function GridView() {
        var header;
        var rows = [];
        var selector;
        this.header = header;
        this.rows = rows;
        this.selector = selector;
    }

    GridView.prototype.insertTo = function (selector) {
        this.selector = selector;
    }

    GridView.prototype.addHeader = function () {
        var header = new Header();
        header.addHeader(arguments);

        this.header = header;
    }

    GridView.prototype.addRow = function () {
        var newRow = new Row();
        var currentRowElements = newRow.addElements(arguments);

        this.rows.push(currentRowElements);

        return newRow;
    }

    GridView.prototype.render = function () {
        var gridHolder = $(this.selector);

        /*Used for nested grid, because we haven't selector*/
        if (!this.selector) {
            gridHolder = $('<div></div>');
            gridHolder.addClass('nested-grid-view');
        }

        if (this.header) {
            var headerElement = this.header.render();
            gridHolder.append(headerElement);
        }

        if (this.rows.length > 0) {
            for (var i = 0; i < this.rows.length; i++) {
                var currRow = this.rows[i].render();
                gridHolder.append(currRow);
            }
        }

        /*Used for nested grid, because we have not selector*/
        if (!this.selector) {
            return gridHolder;
        }
    }

    /*------------------------ Header ------------------------*/
    function Header() {
        var headerElements = [];
        this.headerElements = headerElements;
    }

    Header.prototype.addHeader = function (args) {
        for (var i = 0; i < args.length; i++) {
            this.headerElements.push(args[i]);
        }

        return this;
    }

    Header.prototype.render = function () {
        var headerContainer = $('<div></div>');
        headerContainer.addClass('grid-header');

        if (this.headerElements.length > 0) {
            for (var i = 0; i < this.headerElements.length; i++) {
                var headerElemetn = $('<div></div>');
                headerElemetn.addClass('header-element');
                headerElemetn.text(this.headerElements[i]);
                headerContainer.append(headerElemetn);
            }
        }

        return headerContainer;
    }

    /*------------------------ Rows ------------------------*/
    function Row() {
        var rowElements = [];
        this.rowElements = rowElements;
        var nestedGridView;
        this.nestedGridView = nestedGridView;
    }

    Row.prototype.addElements = function (args) {
        for (var i = 0; i < args.length; i++) {
            this.rowElements.push(args[i]);
        }

        return this;
    }

    Row.prototype.render = function () {
        var rowContainer = $('<div></div>');
        rowContainer.addClass('grid-row collapsed');

        /*add function for collapse-expand*/
        rowContainer.bind('click', function (ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            if (rowContainer.attr('class') == 'grid-row collapsed') {
                rowContainer.removeClass('collapsed');
                rowContainer.addClass('expanded');
            }
            else {
                rowContainer.removeClass('expanded');
                rowContainer.addClass('collapsed');
            }
        });

        if (this.rowElements.length > 0) {
            for (var i = 0; i < this.rowElements.length; i++) {
                var rowElemetn = $('<div></div>');
                rowElemetn.addClass('row-element');
                rowElemetn.text(this.rowElements[i]);
                rowContainer.append(rowElemetn);
            }
        }

        /*Check for nested grid*/
        if (this.nestedGridView) {
            var nestedGrid = this.nestedGridView.render();
            rowContainer.append(nestedGrid);
        }

        return rowContainer;
    }

    Row.prototype.addNestedGridView = function () {
        var nestedGrid = new GridView();
        this.nestedGridView = nestedGrid;

        return nestedGrid;
    }
    
    /*------------------------ Test tasks 1, 2, 3 ------------------------*/
    var schoolGrid = new GridView();
    schoolGrid.insertTo('#grid-view-holder');
    schoolGrid.addHeader('Name', 'Logation', 'Total Students', 'Speciality');
    schoolGrid.addRow('PMG', 'Burgas', '400', 'Math');
    schoolGrid.addRow('Telerik Academy', 'Sofia', '400', 'Math');
    schoolGrid.addRow('Tues', 'Sofia', '500', 'Math');
    /*Add nested grid*/
    var rowWithNestedGrid = schoolGrid.addRow('UNSS', 'Sofia', '1000', 'Math');
    var nestedGridView = rowWithNestedGrid.addNestedGridView();
    nestedGridView.addHeader('Name', 'Logation', 'Total Students', 'Speciality');
    nestedGridView.addRow('PMG', 'Burgas', '400', 'Math');
    nestedGridView.addRow('Telerik Academy', 'Sofia', '400', 'Math');
    nestedGridView.addRow('Tues', 'Sofia', '500', 'Math');

    schoolGrid.render();
});