import { ReactElement } from "react";
//import { LocalizedElementMap } from 'react-localize-redux';

export declare type ColumnSetting = {
    Key: string;
    Title: string | ReactElement<'span'>; //| LocalizedElementMap;
    Visible: boolean;
    IsNonCollapsible?: boolean;
    IsDate?: boolean;
    IsDateTime?: boolean;
    IsTaskDashboardRelated?: boolean;
    Index?: number;
    Width?: string | number;
};

export const sortAlphabeticaly = (a: string, b: string) => {
    if (a === null || a === undefined) {
        return 1;
    }
    if (b === null || b === undefined) {
        return -1;
    }
    let aLowerCased = a.toString().toLowerCase();
    let bLowerCased = b.toString().toLowerCase();

    if (aLowerCased < bLowerCased) {
        return -1;
    } else if (aLowerCased > bLowerCased) {
        return 1;
    } else {
        return 0;
    }
};

export const getFilterValuesByPropertyName = (
    objects: Array<any>,
    propertyName: string,
    nestedPropertyName: string = '',
    nestedPropertyIsArray: boolean = false,
    nestedPropertyIsStringArray: boolean = false,
    numberValuesSorting: boolean = false
) => {
    
    let names: any[] = [];
    if (!objects || objects.length === 0) {
        return names;
    }

    for (let key in objects) {
        if (objects[key][propertyName]) {
            const property = objects[key][propertyName];
            if (nestedPropertyIsArray) {
                for (let innerKey in property) {
                    names.push({
                        text: property[innerKey].toString(),
                        value: property[innerKey].toString()
                    });
                }
            } else if (nestedPropertyIsStringArray) {
                let objectArray = objects[key][propertyName].split(';').map((cl: string) => parseInt(cl, 10));
                objectArray.forEach((element: any) => {
                    names.push({
                        text: element,
                        value: element
                    });
                });
            } else {
                let propertyValue;
                if (nestedPropertyName && property[nestedPropertyName]) {
                    propertyValue = property[nestedPropertyName].toString().trim();
                } else {
                    propertyValue = property.toString().trim();
                }

                if (propertyValue !== '') {
                    names.push({
                        text: propertyValue,
                        value: propertyValue
                    });
                }
            }
        }
    }
    // get unique values
    let uniquenames = names.filter((filterItem: any, index: any, array: any) =>
        index === array.findIndex((item: any) => (
            item.text === filterItem.text && item.value === filterItem.value
        ))
    );

    // sort by values
    if (nestedPropertyIsStringArray) {
        uniquenames = uniquenames.sort((a, b) => sortNumbers(a.value, b.value));
    } else {
        uniquenames = uniquenames.sort((a, b) => sortAlphabeticaly(a.text, b.text));
    }

    if (numberValuesSorting) {
        uniquenames.sort((el1, el2) => Number(el1.value) - Number(el2.value));
    }
    return uniquenames;
};

export const sortDates = (a: Date, b: Date) => {
    if (a === null || a === undefined) {
        return 1;
    }
    if (b === null || b === undefined) {
        return -1;
    }
    if (a < b) {
        return -1;
    } else if (a > b) {
        return 1;
    } else {
        return 0;
    }
};

export const sortNumbers = (a: number, b: number) => {
    if (a === null || a === undefined) {
        return 1;
    }
    if (b === null || b === undefined) {
        return -1;
    }
    if (a < b) {
        return -1;
    } else if (a > b) {
        return 1;
    } else {
        return 0;
    }
};