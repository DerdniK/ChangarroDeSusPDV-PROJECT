import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class AuthService {
  static const _storage = FlutterSecureStorage();
  static const String _baseUrl = 'https://lvk5buixqe.execute-api.us-east-1.amazonaws.com/api';

  static Future<bool> login(String username, String password) async {
    final url = Uri.parse('$_baseUrl/auth');

    try {
      final response = await http.post(
        url,
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'Username': username,
          'Password': password,
        }),
      );

      if (response.statusCode == 200) {
        final data = jsonDecode(response.body);

        if (data['success'] == true) {
          final String token = data['authData']['token'];
          await _storage.write(key: 'jwt_token', value: token);
          return true;
        }
      }
      return false;
    } catch (e) {
      print('Error en login: $e');
      return false;
    }
  }

  static Future<String?> getToken() async {
    return await _storage.read(key: 'jwt_token');
  }

  static Future<void> logout() async {
    await _storage.delete(key: 'jwt_token');
  }
}