class ProductType {
  final int typeId;
  final String typeName;

  ProductType({
    required this.typeId,
    required this.typeName,
  });

  factory ProductType.fromJson(Map<String, dynamic> json) {
    return ProductType(
      typeId: json['typeId'] ?? 0,
      typeName: json['typeName'] ?? '',
    );
  }
}
class Product {
  final int productId;
  final String name;
  final String sku;
  final ProductType? type;
  final double price;
  final String imageUrl;

  Product({
    required this.productId,
    required this.name,
    required this.sku,
    this.type,
    required this.price,
    required this.imageUrl,
  });

  factory Product.fromJson(Map<String, dynamic> json) {
    return Product(
      productId: json['productId'] ?? 0,
      name: json['name'] ?? 0,
      sku: json['sku'] ?? 0,
      type: json['type'] != null ? ProductType.fromJson(json['type']) : null,
      price: (json['price'] as num).toDouble() ?? 0.0,
      imageUrl: json['imageURL'] ?? '',
    );
  }
}