export type Item = {
  id: number;
  sku: String;
  name: String;
  description: String | null;
  inventoryRecords: [];
  lots: [];
};
