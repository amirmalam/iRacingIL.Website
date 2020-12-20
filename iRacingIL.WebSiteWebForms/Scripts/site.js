function createHeatTable(array, data, cells) {
    // Run for each item in the array of coluns need to be highlighted.
    for (let i = 0; i < array.length; i++) {
        let j = array[i];
        highlightCells(j.tableid, data[j.colIndex], cells[j.colIndex], j.levels, j.cssname, j)
    }
}
function highlightCells(tableid, val, cell, levels, baseclass, json) {
    if (val < 1)
        return;


    // The diff value is 0 when we start, so calculate max, min and diff values.
    if (json.diffValue == 0) {
        highlightCellsInit(tableid, levels, json)
    }


    index = levels + 1 - Math.round((((val - json.minValue) / json.diffValue) + 0.5));
    if (index == 0)
        index = 1;

    $(cell).addClass(baseclass + index);

}
function highlightCellsInit(tableid, levels, uid) {
    $("#" + tableid).find('tr').each(function (i, el) {
        var $tds = $(this).find('td');
        val = parseInt($tds.eq(uid.colIndex).text());
        if (uid.maxValue < val)
            uid.maxValue = val;
        else if (uid.minValue > val)
            uid.minValue = val;
    });
    if (uid.minValue == 0) uid.minValue = 1;
    uid.diffValue = ((uid.maxValue - uid.minValue) / levels);
}

