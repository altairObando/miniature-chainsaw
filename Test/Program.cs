//// See https://aka.ms/new-console-template for more information
using System.Text.Json;

var javascript = @"
// Responsables de los cuarteles
const paddockManagers = [
    { id: 1, taxNumber: '132254524', name: 'JUAN TAPIA BURGOS'},
    { id: 2, taxNumber: '143618668', name: 'EFRAIN SOTO VERA'},
    { id: 3, taxNumber: '78903228', name: 'CARLOS PEREZ GONZALEZ'},
    { id: 4, taxNumber: '176812737', name: 'ANDRES VIÑALES CIENFUEGOS'},
    { id: 5, taxNumber: '216352696', name: 'OSCAR PEREZ ZUÑIGA'},
    { id: 6, taxNumber: '78684747', name: 'JOAQUIN ANDRADE SANDOVAL' }
];
const paddockType = [
{ id: 1, name: 'PALTOS' },
{ id: 2, name: 'AVELLANOS' },
{ id: 3, name: 'CEREZAS' },
{ id: 4, name: 'NOGALES' },
]
const paddocks = [
    { paddockManagerId: 6, farmId: 1, paddockTypeId: 1, harvestYear: 2019, area: 1200 },
    { paddockManagerId: 1, farmId: 3, paddockTypeId: 4, harvestYear: 2019, area: 500 },
    { paddockManagerId: 5, farmId: 3, paddockTypeId: 2, harvestYear: 2020, area: 20000 },
    { paddockManagerId: 2, farmId: 2, paddockTypeId: 3, harvestYear: 2021, area: 8401},
    { paddockManagerId: 3, farmId: 1, paddockTypeId: 1, harvestYear: 2020, area: 2877 },
    { paddockManagerId: 5, farmId: 2, paddockTypeId: 2, harvestYear: 2017, area: 15902 },
    { paddockManagerId: 3, farmId: 3, paddockTypeId: 2, harvestYear: 2018, area: 1736 },
    { paddockManagerId: 2, farmId: 3, paddockTypeId: 3, harvestYear: 2020, area: 2965 },
    { paddockManagerId: 4, farmId: 3, paddockTypeId: 4, harvestYear: 2018, area: 1651 },
    { paddockManagerId: 5, farmId: 1, paddockTypeId: 1, harvestYear: 2018, area: 700 },
    { paddockManagerId: 1, farmId: 2, paddockTypeId: 1, harvestYear: 2019, area: 7956 },
    { paddockManagerId: 5, farmId: 3, paddockTypeId: 2, harvestYear: 2020, area: 3745 },
    { paddockManagerId: 6, farmId: 1, paddockTypeId: 3, harvestYear: 2021, area: 11362 },
    { paddockManagerId: 2, farmId: 3, paddockTypeId: 3, harvestYear: 2021, area: 300 },
    { paddockManagerId: 3, farmId: 2, paddockTypeId: 2, harvestYear: 2020, area: 19188 },
    { paddockManagerId: 3, farmId: 1, paddockTypeId: 1, harvestYear: 2019, area: 17137 },
    { paddockManagerId: 4, farmId: 3, paddockTypeId: 2, harvestYear: 2020, area: 100 },
    { paddockManagerId: 2, farmId: 1, paddockTypeId: 3, harvestYear: 2019, area: 11845 },
    { paddockManagerId: 5, farmId: 2, paddockTypeId: 1, harvestYear: 2018, area: 15969 },
    { paddockManagerId: 1, farmId: 3, paddockTypeId: 1, harvestYear: 2029, area: 10420 },
    { paddockManagerId: 5, farmId: 2, paddockTypeId: 3, harvestYear: 2010, area: 3200 },
    { paddockManagerId: 6, farmId: 1, paddockTypeId: 2, harvestYear: 2012, area: 10587 },
    { paddockManagerId: 2, farmId: 2, paddockTypeId: 2, harvestYear: 2018, area: 16750 }
];
const farms = [
    { id: 1, name: 'AGRICOLA SANTA ANA' },
    { id: 2, name: 'VINA SANTA PAULA' },
    { id: 3, name: 'FORESTAL Y AGRICOLA LO ENCINA' }
];
// 0 Arreglo con los ids de los responsables de cada cuartel
function listPaddockManagerIds() {
return paddockManagers.map((paddockManager) => paddockManager.id);
}
// 1 Arreglo con los ruts de los responsables de los cuarteles, ordenados por nombre
function listPaddockManagersByName() {
    return sortByProperty('name', paddockManagers).map( manager => manager.taxNumber);
}
// 2 Arreglo con los nombres de cada tipo de cultivo, ordenados decrecientemente por la suma TOTAL de la cantidad de hectáreas plantadas de cada uno de ellos.
function sortPaddockTypeByTotalArea() {
    const newPaddocks = paddockType.map( pad => {
        const { area : sum } = sumByProperty('area', paddocks.filter( p => p.paddockTypeId == pad.id), { area: 0 });
        return { ...pad, Total : sum }
    })
    return sortByProperty('Total', newPaddocks );
}
// 3 Arreglo con los nombres de los administradores, ordenados decrecientemente por la suma TOTAL de hectáreas que administran.
function sortFarmManagerByAdminArea() {
    const newPaddocks = paddockManagers.map( manager => {
        const { area: suma } = sumByProperty('area', paddocks.filter( p => p.paddockManagerId === manager.id), { area : 0 });
        return { ...manager, total: suma }
    });
    return sortByProperty('total', newPaddocks).map( item => ({ name: item.name, total: item.total }));
}
// 4 Objeto en que las claves sean los nombres de los campos y los valores un arreglo con los ruts de sus administradores ordenados alfabéticamente por nombre.
function farmManagerNames() {
    return farms.reduce(( grupo, farm )=> {
        grupo[farm.name] = grupo[farm.name] || [];
        // Obtener los nombres de los administradores ordenados.
        let managers = paddocks.filter( pad => pad.farmId === farm.id)
            .map(pad => {
                const [ manager ] = paddockManagers.filter( man => man.id === pad.paddockManagerId);
                return manager;
            }).sort((a,b) => a.name > b.name ? 1 : b.name > a.name ? -1 : 0);
        grupo[farm.name].push( ...managers );
        return grupo;
    }, [])
}
// 5 Arreglo ordenado decrecientemente con los m2 totales de cada campo que tenga más de 2 hectáreas en Paltos
function biggestAvocadoFarms() {
    const FACTOR = 10_000, 
          PALTO_ID = 1, 
          LIMIT = 2;
    return farms.map( farm => {
        let totalPaltos = paddocks.filter( pad => pad.farmId === farm.id && pad.paddockTypeId === PALTO_ID).reduce((sum, pad) =>{ sum.area += pad.area; return sum;  }, { area: 0 }).area;
        return {...farm, total: totalPaltos / FACTOR };
    }).filter( item => item.total > LIMIT)
      .sort((a,b) => b.total - a.total)
      .map( item => ({ name: item.name, total: `${item.total.toLocaleString('en-us',{ minimumFractionDigits: 2 })} mts2` }))
}  

/**
 * 
 * @param { String } propName Nombre de la propiedad
 * @param { Arrray } array Arreglo de elementos
 * @param { Boolean } desc Indica si sera descendente
 * @returns { Array } sorted
 */
function sortByProperty(propName, array, desc=false){
    const sorted = (array || []).sort(( a, b) => a[propName] > b[propName] ? 1 : b[propName] > a[propName] ? -1 : 0 );
    if(desc)
        return sorted.reverse();
    return sorted;
}

function sumByProperty(propName, array, initialValue){
    return array.reduce((group, row)=> { group[propName] += row[propName]; return group; } , initialValue)
}

return biggestAvocadoFarms();
";

//var result = BL.Javascript.CustomEngine.Eval(javascript);
var result = BL.Javascript.CustomEngine.Eval(@"
doCmd({command:'Contacts', operation:'GET', filter: 'id > 0', fields:'id, name, maritalstatus' }); 

return Contacts.Results.reduce( ( group, row ) => { 
        group[row.MaritalStatus] = group[row.MaritalStatus] || [];
        group[row.MaritalStatus].push(row.Name);
        return group;
    },{})

");
Console.WriteLine(result);
Console.ReadKey();