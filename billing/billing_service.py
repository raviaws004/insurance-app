from flask import Flask, jsonify, request

app = Flask(__name__)
billings = {}

@app.route('/billing', methods=['POST'])
def create_billing():
    data = request.json
    billing_id = str(len(billings) + 1)
    billings[billing_id] = data
    return jsonify({"billing_id": billing_id, "billing": data}), 201

@app.route('/billing/<billing_id>', methods=['GET'])
def get_billing(billing_id):
    billing = billings.get(billing_id)
    if billing:
        return jsonify({"billing_id": billing_id, "billing": billing})
    return jsonify({"error": "Billing not found"}), 404

if __name__ == '__main__':
    app.run(port=5002)