import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:machapoint/Pages/HomePage.dart';

class InicioPage extends StatefulWidget {
  const InicioPage({super.key});

  @override
  State<InicioPage> createState() => _InicioPageState();
}

class _InicioPageState extends State<InicioPage> {
  bool isLoading = false;

  Future<void> _verificarBackendYNavegar() async {
  setState(() => isLoading = true);
  final url = Uri.parse('https://lvk5buixqe.execute-api.us-east-1.amazonaws.com/api/health');

  try {
    final response = await http.get(url).timeout(const Duration(seconds: 5));
    if (!mounted) return;
    if (response.statusCode == 200) {
      final data = jsonDecode(response.body);

      final String status = data['status'] ?? 'Ok';
      final String version = data['version'] ?? 'Sin versión';

      
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Conexion exitosa ($status) - Version: $version'),
          backgroundColor: Colors.green,
        ),
      );

      
      // Navigator.pushReplacement(
      //   context,
      //   MaterialPageRoute(
      //     builder: (context) => const Homepage(),
      //   ),
      // );
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('El backend respondio trono: ${response.statusCode}'),
          backgroundColor: Colors.orange,
        ),
      );
    }
  } catch (e) {
    if (!mounted) return;
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text('No se pudo conectar al Backend: $e'),
        backgroundColor: Colors.red,
      ),
    );
  } finally {
    if (mounted) setState(() => isLoading = false);
  }
}

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(20),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              const Text(
                '🦝',
                style: TextStyle(fontSize: 90, fontWeight: FontWeight.bold),
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 20),
              const Text(
                'Bienvenido a MachaPoint',
                style: TextStyle(fontSize: 28, fontWeight: FontWeight.bold),
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 10),
              const SizedBox(height: 40),
              ElevatedButton.icon(
                style: ElevatedButton.styleFrom(
                  minimumSize: const Size(220, 50),
                  backgroundColor: Colors.indigo,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10),
                  ),
                ),
                onPressed: isLoading ? null : _verificarBackendYNavegar,
                icon: isLoading
                    ? const SizedBox(
                        width: 20,
                        height: 20,
                        child: CircularProgressIndicator(color: Colors.white, strokeWidth: 2),
                      )
                    : const Icon(Icons.wifi, color: Colors.white),
                label: Text(
                  'Probar conexion',
                  style: const TextStyle(color: Colors.white, fontSize: 16),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}