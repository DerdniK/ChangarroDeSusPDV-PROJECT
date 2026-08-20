import 'dart:convert';
import 'package:http/http.dart' as http;
import '../models/produtos.dart';
import 'auth.dart';

class ProductService {
  static const String _baseUrl = 'https://lvk5buixqe.execute-api.us-east-1.amazonaws.com/api';

  static Future<List<Product>> getProducts() async {
    final token = await AuthService.getToken();

    if (token == null) {
      throw Exception('Error al iniciar sesion');
    }

    final url = Uri.parse('$_baseUrl/products');

    final response = await http.get(
      url,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer $token',
      },
    );

    if (response.statusCode == 200) {
      final List<dynamic> jsonList = jsonDecode(response.body);
      return jsonList.map((json) => Product.fromJson(json)).toList();
    } else if (response.statusCode == 401) {
      await AuthService.logout();
      throw Exception('Sesión expirada.');
    } else {
      throw Exception('Error al obtener productos: ${response.statusCode}');
    }
  }
}