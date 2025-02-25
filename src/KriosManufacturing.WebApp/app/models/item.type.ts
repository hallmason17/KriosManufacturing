export interface Item {
    id: number;
    sku: string;
    name: string;
    description: string | null;
    inventoryRecords: [];
    lots: [];
}
